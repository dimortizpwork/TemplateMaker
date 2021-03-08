using System.Data;
using Coolblue.Utilities.Data.Timing;
using Coolblue.Utilities.Resilience.Oracle.Core;
using Dapper;
using {{SolutionName}}.Models;
using {{SolutionName}}.Oracle.Adapter.Dto;
using {{SolutionName}}.Oracle.Adapter.Helpers;
using {{SolutionName}}.Repositories;

namespace {{SolutionName}}.Oracle.Adapter.Repositories
{
    public class {{SolutionName}}Repository : AbstractOracleRepository, IInviteToPayRepository
    {
        private const string MonitoringGet = "MonitoringGet";
        private const string MonitoringPost = "MonitoringPost";
        private const string MonitoringPut = "MonitoringPut";
        private const string MonitoringDelete = "MonitoringDeleteInviteToPay";

        private const string GetQuery =
           @"select
                INVITETOPAYID,
                INVITETOPAYSTATEID,
                UNIQUEREFERENCE,
                SHOPID,
                CURRENCYID,
                AMOUNT,
                EXPIRYDATETIME,
                ORDERID,
                INVOICEID,
                CUSTOMERID,
                CUSTOMERINFORMATION,
                INVITATIONUSERID,
                INVITATIONDATETIME,
                CONFIRMATIONDATETIME,
                ALLOWPAYMENTCOST,
                LEAVEPAYMENTMETHOD,
                SENDSMS,
                SMSNUMBER
            from table(VAN_PKG_INVITETOPAY.GET(:P_ID))";

        private const string PostQuery =
             @"begin
                VAN_PKG_INVITETOPAY.PUT(
                    :P_INVITETOPAYSTATEID,
                    :P_UNIQUEREFERENCE,
                    :P_SHOPID,
                    :P_CURRENCYID,
                    :P_AMOUNT,
                    :P_EXPIRYDATETIME,
                    :P_ORDERID,
                    :P_INVOICEID,
                    :P_CUSTOMERID,
                    :P_CUSTOMERINFORMATION,
                    :P_INVITATIONUSERID,
                    :P_INVITATIONDATETIME,
                    :P_CONFIRMATIONDATETIME,
                    :P_ALLOWPAYMENTCOST,
                    :P_LEAVEPAYMENTMETHOD,
                    :P_SENDSMS,
                    :P_SMSNUMBER,
                    :P_ID)
              end;";
        private const string PutQuery =
            @"begin
                VAN_PKG_INVITETOPAY.PUT(
                    :P_INVITETOPAYSTATEID,
                    :P_UNIQUEREFERENCE,
                    :P_SHOPID ,
                    :P_CURRENCYID,
                    :P_AMOUNT,
                    :P_EXPIRYDATETIME,
                    :P_ORDERID,
                    :P_INVOICEID,
                    :P_CUSTOMERID,
                    :P_CUSTOMERINFORMATION,
                    :P_INVITATIONUSERID,
                    :P_INVITATIONDATETIME,
                    :P_CONFIRMATIONDATETIME,
                    :P_ALLOWPAYMENTCOST,
                    :P_LEAVEPAYMENTMETHOD,
                    :P_SENDSMS,
                    :P_SMSNUMBER); 
              end;";

        private const string DeleteQuery =
           @"begin
                VAN_PKG_INVITETOPAY.DELETE(:P_ID); 
              end;";

        public {{SolutionName}}Repository(ITimingDbConnectionFactory connectionFactory, OracleResiliencePolicy resiliencePolicy) : base(
           connectionFactory, resiliencePolicy)
        {

        }

        public void Delete(long InviteToPayId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("P_ID", InviteToPayId);

            ExecuteWithPolicy(() => {
                return Connection.Execute("DeleteQuery", DeleteQuery, parameters);
            }, MonitoringDeleteInviteToPay);
        }

        public {{ModelName}}Model Get(long InviteToPayId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("P_ID", InviteToPayId);

            return ExecuteWithPolicy(() => {
                Connection.Open();
                var dto = Connection.QueryFirst<{{ModelName}}Dto>("GetQuery", GetQuery, parameters);
                return dto.ToModel();
            }, MonitoringGetInviteToPay);
        }

        public int Post({{ModelName}}Model model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("P_INVITETOPAYSTATEID", model.InviteToPayStateId);
            parameters.Add("P_UNIQUEREFERENCE", model.UniqueReference);
            parameters.Add("P_SHOPID", model.ShopId);
            parameters.Add("P_CURRENCYID", model.CurrencyId);
            parameters.Add("P_AMOUNT", model.Amount);
            parameters.Add("P_EXPIRYDATETIME", model.ExpiryDateTime);
            parameters.Add("P_ORDERID", model.OrderId);
            parameters.Add("P_INVOICEID", model.InvoiceId);
            parameters.Add("P_CUSTOMERID", model.CustomerId);
            parameters.Add("P_CUSTOMERINFORMATION", model.CustomerInformation);
            parameters.Add("P_INVITATIONUSERID", model.InvitationUserId);
            parameters.Add("P_INVITATIONDATETIME", model.InvitationDateTime);
            parameters.Add("P_CONFIRMATIONDATETIME", model.ConfirmationDateTime);
            parameters.Add("P_ALLOWPAYMENTCOST", OracleHelper.GetOracleBoolean(model.AllowPaymentCost));
            parameters.Add("P_LEAVEPAYMENTMETHOD", OracleHelper.GetOracleBoolean(model.LeavePaymentMethod));
            parameters.Add("P_SENDSMS", OracleHelper.GetOracleBoolean(model.SendSMS));
            parameters.Add("P_SMSNUMBER", model.SMSNumber);
            parameters.Add("P_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            return ExecuteWithPolicy(() => {
                Connection.Execute("PostQuery", PostQuery, parameters);
                return parameters.Get<int>("P_ID");
            }, MonitoringPostInviteToPay);
        }

        public void Put(long inviteToPayId, {{ModelName}}Model model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("P_ID", inviteToPayId);
            parameters.Add("P_INVITETOPAYSTATEID", model.InviteToPayStateId);
            parameters.Add("P_UNIQUEREFERENCE", model.UniqueReference);
            parameters.Add("P_SHOPID", model.ShopId);
            parameters.Add("P_CURRENCYID", model.CurrencyId);
            parameters.Add("P_AMOUNT", model.Amount);
            parameters.Add("P_EXPIRYDATETIME", model.ExpiryDateTime);
            parameters.Add("P_ORDERID", model.OrderId);
            parameters.Add("P_INVOICEID", model.InvoiceId);
            parameters.Add("P_CUSTOMERID", model.CustomerId);
            parameters.Add("P_CUSTOMERINFORMATION", model.CustomerInformation);
            parameters.Add("P_INVITATIONUSERID", model.InvitationUserId);
            parameters.Add("P_INVITATIONDATETIME", model.InvitationDateTime);
            parameters.Add("P_CONFIRMATIONDATETIME", model.ConfirmationDateTime);
            parameters.Add("P_ALLOWPAYMENTCOST", OracleHelper.GetOracleBoolean(model.AllowPaymentCost));
            parameters.Add("P_LEAVEPAYMENTMETHOD", OracleHelper.GetOracleBoolean(model.LeavePaymentMethod));
            parameters.Add("P_SENDSMS", OracleHelper.GetOracleBoolean(model.SendSMS));
            parameters.Add("P_SMSNUMBER", model.SMSNumber);
            
            ExecuteWithPolicy(() => {
                return Connection.Execute("PutQuery", PutQuery, parameters);
            }, MonitoringPutInviteToPay);
        }
    }
}
