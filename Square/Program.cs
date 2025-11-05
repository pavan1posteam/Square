using Square.Models;
using System;
using System.Configuration;

namespace Square
{
    class Program
    {
        private static void Main(string[] args)
        {
            string DeveloperId = ConfigurationManager.AppSettings["DeveloperId"];
            try
            {
                POSSettings pOSSettings = new POSSettings();
                pOSSettings.IntializeStoreSettings();
                foreach (POSSetting current in pOSSettings.PosDetails)
                {
                    try
                    {
                        if (current.PosName.ToUpper() == "SQUAREPOS")
                        {
                            
                                clsSquarePos clsSquarePos = new clsSquarePos(current.StoreSettings.StoreId, current.StoreSettings.POSSettings.APIKey, DeveloperId, current.StoreSettings.POSSettings.category, current.StoreSettings.POSSettings.tax, current.StoreSettings.POSSettings.LocationId);
                                Console.WriteLine();
                            
                        }
                         
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                    }
                }
            }

            catch (Exception ex)
            {
                new clsEmail().sendEmail(DeveloperId, "", "", "Error in ExtractPOS@" + DateTime.UtcNow + " GMT", ex.Message + "<br/>" + ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
        }
    }
}
