#region Using

using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.OleDb;
using System.IO;
using Newtonsoft.Json;

using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;


#endregion

#region Copyright

// Пример к статье: http://www.softez.pp.ua/2015/04/27/mouse-events-emulation-geckofx/
// Автор: dredei

#endregion

namespace DauaAisGek
{
    internal class EmulMouseEvents
    {
    //    private readonly GeckoWebBrowser browser; // ссылка на браузер
        private readonly Timer _loadingTimer; // таймер загрузки
        private bool _loading; // указывает на статус загрузки

        string BUXFRM;
        string BUXIIN;
        string BUXOPT;
        string BUXDATBEG;
        string BUXDATEND;
        int PrgCnd = 0;
        int j = 0;
        int i = 0;

        string[,] MasUsl = new string[150, 10];
        int UslKol;

        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\DauaExpToApp\APPLOG.MDB";
        OleDbConnection conOtl;
        OleDbCommand cmdOtl;


        //=============================================== установки
        int PauseVal = 1000;
        int KolLim = 0;     // кол секунд после чего прерывается ожидание
        string Pol = "";
        string sz = "";

        FrmMain FrmMsg = ((FrmMain)Application.OpenForms["FrmMain"]);

        public async void Start()
        {
            BUXFRM = "1";
            BUXOPT = "START";
            //BUXDATBEG = "01.10.2019"; ;
            //BUXDATEND = "31.10.2019";

            UpLoad();

            // ============================== отладка  =================================================================================================================      
            conOtl = new OleDbConnection(connectionString);
            conOtl.Open();
            //cmdOtl = new OleDbCommand("DELETE * FROM TABLOG", conOtl);
            //cmdOtl.ExecuteNonQuery();
            // ============================== отладка 

            while (PrgCnd == 0)
            {

                string Token = "";

                GeckoMouseEvents.AppService.ServiceElement[] xmldata = new GeckoMouseEvents.AppService.ServiceElement[200];
                GeckoMouseEvents.AppService.ServicesBatchResult xmlResult = new GeckoMouseEvents.AppService.ServicesBatchResult();

                // ******************************************************************************************************************************************
                GeckoMouseEvents.DopService.Service1SoapClient DopService = new GeckoMouseEvents.DopService.Service1SoapClient();
                DataSet Ais001 = new DataSet("Ais001");
                Ais001.Merge(DopService.DopHspExpApp(BUXFRM, BUXOPT, BUXDATBEG, BUXDATEND));

                j = -1;
                if (Ais001.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(Ais001.Tables[0].Rows[0]["xPrim"]) == "КОНЕЦ ФАИЛА")
                    {
                        //cmdOtl = new OleDbCommand("INSERT INTO TABLOG (LOGMESSAGE) VALUES ('КОНЕЦ ФАИЛА')", conOtl);
                        //cmdOtl.ExecuteNonQuery();
                        //conOtl.Close();

                        PrgCnd = 9;
                        BUXOPT = "";
                        MessageBox.Show("КОНЕЦ ФАИЛА", "АПП расчет", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        break;
                    }
                    if (Convert.ToString(Ais001.Tables[0].Rows[0]["xPrim"]) == "ТОКЕН ИСТЕК СРОК")
                    {
                        //cmdOtl = new OleDbCommand("INSERT INTO TABLOG (LOGMESSAGE) VALUES ('ТОКЕН ИСТЕК СРОК')", conOtl);
                        //cmdOtl.ExecuteNonQuery();
                        //conOtl.Close();

                        PrgCnd = 9;
                        BUXOPT = "";
                        MessageBox.Show("ТОКЕН ИСТЕК СРОК", "АПП расчет", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        break;
                    }

                    UslKol = 0;
                    foreach (DataRow row in Ais001.Tables[0].Rows)
                    {
                        j++;

                        xmldata[j] = new GeckoMouseEvents.AppService.ServiceElement();

                        xmldata[j].ID = Convert.ToUInt32(row["xID"]);
                        xmldata[j].Date = Convert.ToDateTime(row["xDate"]);
                        xmldata[j].Customer = Convert.ToUInt64(row["xCustomer"]);
                        xmldata[j].Performer = Convert.ToUInt64(row["xPerformer"]);
                        xmldata[j].CustomerDepartament = Convert.ToUInt32(row["xCustomerDepartament"]);
                        xmldata[j].PerformerDepartament = Convert.ToUInt32(row["xPerformerDepartament"]);
                        xmldata[j].CustomerEmployee = Convert.ToUInt32(row["xCustomerEmployee"]);
                        xmldata[j].PerformerEmployee = Convert.ToUInt32(row["xPerformerEmployee"]);
                        xmldata[j].ServiceID = Convert.ToUInt32(row["xServiceID"]);
                        xmldata[j].PatientID = Convert.ToUInt32(row["xPatientID"]);
                        xmldata[j].PatientFirstName = Convert.ToString(row["xPatientFirstName"]);
                        xmldata[j].PatientLastName = Convert.ToString(row["xPatientLastName"]);
                        xmldata[j].PatientMiddleName = Convert.ToString(row["xPatientMiddleName"]);
                        xmldata[j].PatientSexID = Convert.ToUInt32(row["xPatientSexID"]);
                        xmldata[j].PatientIDN = Convert.ToString(row["xPatientIDN"]);
                        xmldata[j].PatientBirthDate = Convert.ToDateTime(row["xPatientBirthDate"]);
                        xmldata[j].FinanceSourceID = Convert.ToUInt32(row["xFinanceSourceID"]);
                        xmldata[j].VisitKindID = Convert.ToUInt32(row["xVisitKindID"]);
                        xmldata[j].TreatmentReasonID = Convert.ToUInt32(row["xTreatmentReasonID"]);
                        xmldata[j].Cost = Convert.ToUInt32(row["xCost"]);
                        xmldata[j].Count = Convert.ToUInt32(row["xCount"]);
                        xmldata[j].ServiceKind2 = Convert.ToBoolean(row["xServiceKind2"]);
                        xmldata[j].LeasingID = Convert.ToString(row["xLeasingID"]);
                        xmldata[j].MKB10 = Convert.ToString(row["xMKB10"]);
                        xmldata[j].DoctorFirstName = Convert.ToString(row["xDoctorFirstName"]);
                        xmldata[j].DoctorLastName = Convert.ToString(row["xDoctorLastName"]);
                        xmldata[j].DoctorMiddleName = Convert.ToString(row["xDoctorMiddleName"]);
                        xmldata[j].ServiceKind = Convert.ToUInt32(row["xServiceKind"]);
                        xmldata[j].ServiceCDSKind = Convert.ToUInt32(row["xServiceCDSKind"]);
                      //  xmldata[j].PaymentType = Convert.ToSByte(row["xPaymentType"]);
                        xmldata[j].DateVerified = Convert.ToDateTime(row["xDateVerified"]);
                        xmldata[j].Result = Convert.ToString(row["xResult"]);
                        xmldata[j].Service = Convert.ToString(row["xService"]);
                        xmldata[j].DeleteDate = Convert.ToDateTime(row["xDeleteDate"]);
                        xmldata[j].Place = Convert.ToString(row["xPlace"]);
                        xmldata[j].Visit_type = Convert.ToInt32(row["xVisit_type"]);
                        xmldata[j].Group_id = Convert.ToInt32(row["xGroup_id"]);
                        xmldata[j].Refferal_id = Convert.ToString(row["xRefferal_id"]);
                        xmldata[j].Parent_id = Convert.ToUInt32(row["xParent_id"]);
                        xmldata[j].Diag_type = Convert.ToInt32(row["xDiag_type"]);
                        xmldata[j].Diag_typeSpecified = true;


                        Token = Convert.ToString(row["xToken"]);

                        sz = JsonConvert.SerializeObject(xmldata[j]);

                        BUXOPT = Convert.ToString(xmldata[j].PatientIDN);

                        // ============================== отладка   
                        Pol = Convert.ToString(row["xPatientIDN"]) + " " + Convert.ToString(row["xDate"]).Substring(0,10) + "     " + 
                              Convert.ToString(row["xPatientFirstName"]) + "     " + Convert.ToString(row["xPatientMiddleName"]) + "     " +
                              Convert.ToString(row["xPatientLastName"]) + "     " + Convert.ToString(row["xService"]) + "     " +
                              Convert.ToString(row["xMKB10"]) + "     " + Convert.ToString(row["xPaymentType"]);
                        FrmMsg.MsgShow(Pol);

                        //UslKol++;
                        //MasUsl[UslKol, 0] = Convert.ToString(row["xID"]);
                        //MasUsl[UslKol, 1] = Convert.ToString(row["xDate"]);
                        //MasUsl[UslKol, 2] = Convert.ToString(row["xPatientIDN"]);
                        //MasUsl[UslKol, 3] = Convert.ToString(row["xPatientFirstName"]);
                        //MasUsl[UslKol, 4] = Convert.ToString(row["xPatientMiddleName"]);
                        //MasUsl[UslKol, 5] = Convert.ToString(row["xPatientLastName"]);
                        //MasUsl[UslKol, 6] = Convert.ToString(row["xService"]);
                        //MasUsl[UslKol, 7] = Convert.ToString(row["xMKB10"]);
                        //MasUsl[UslKol, 8] = Convert.ToString(row["xPaymentType"]);

                    }


                    System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

                    try
                    {
                        GeckoMouseEvents.AppService.ExchangeBLPortTypeClient APPServ = new GeckoMouseEvents.AppService.ExchangeBLPortTypeClient();
                        xmlResult = APPServ.SetData(xmldata, Token);

                    }
                    catch (Exception ex)
                    {
                        // display error message or whatever
                        Console.WriteLine("{0} Exception caught.", ex);
                    }


                    if (xmlResult.Message.Length > 0)
                    {
                        MessageBox.Show(xmlResult.Message, "Экспорт в АПП", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        BUXOPT = "";
                    }
                    else
                    {
                        for (var i = 0; i < xmlResult.ResultsMIS.Length; i++)
                        {
                            Pol = "--------------------------------------" +
                                  xmlResult.ResultsMIS[i].Info + " " +
                                  xmlResult.ResultsMIS[i].Status;
                            // ============================== отладка       
                            //cmdOtl = new OleDbCommand("UPDATE TABLOG SET LOGINFO='" + xmlResult.ResultsMIS[i].Info +
                            //                                         "',LOGSTATUS='" + xmlResult.ResultsMIS[i].Status +
                            //                          "' WHERE LOGID='" + Convert.ToString(xmlResult.ResultsMIS[i].ID) + "'", conOtl);
                            //cmdOtl.ExecuteNonQuery();
                            cmdOtl = new OleDbCommand("INSERT INTO TABLOG (LOGID,LOGDAT,LOGIIN,LOGIMA,LOGOTC,LOGFAM,LOGTRF,LOGMKB,LOGOPL,LOGINFO,LOGSTATUS) " +
                                                      "VALUES ('" +
                                                                xmldata[i].ID + "','" +
                                                                xmldata[i].Date + "','" +
                                                                xmldata[i].PatientIDN + "','" +
                                                                xmldata[i].PatientFirstName + "','" +
                                                                xmldata[i].PatientMiddleName + "','" +
                                                                xmldata[i].PatientLastName + "','" +
                                                                xmldata[i].Service + "','" +
                                                                xmldata[i].MKB10 + "','" +
                                                                xmldata[i].TreatmentReasonID + "','" +
                                                                xmlResult.ResultsMIS[i].Info + "','" +
                                                                xmlResult.ResultsMIS[i].Status + "')", conOtl);
                            cmdOtl.ExecuteNonQuery();
                            // ============================== отладка 
                            FrmMsg.MsgShow(Pol);
                        }

                    }


   
                }
                else
                {
                    // ============================== отладка       
                    //cmdOtl = new OleDbCommand("INSERT INTO TABLOG (LOGMESSAGE) VALUES ('Записей нет')", conOtl);
                    //cmdOtl.ExecuteNonQuery();
                    FrmMsg.MsgShow("Записей нет");
                    // ============================== отладка       
                }
                
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        // ============================ загрузка TEXT в базу ==============================================
        public void UpLoad()
        {
            string[] Pol = new string[5];
            String dir = @"C:\DauaExpToApp\Account.txt";
            string Line;

            StreamReader sr = new StreamReader(dir);
            while (!sr.EndOfStream)
            {
                Line = sr.ReadLine();  //получили массив строк
                Pol = Line.Split(' ');
                BUXFRM = Pol[0];
                BUXDATBEG = Pol[1];
                BUXDATEND = Pol[2];
                break;
            }

            sr.Close();
        }

    }
}