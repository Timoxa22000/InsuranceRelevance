using Dapper;
using InsuranceRelevance.Models.Bank;
using InsuranceRelevance.Models.Insurance;
using InsuranceRelevance.Models.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceRelevance.Models
{
    public interface IRepository
    {
        Task<List<Contract>> GetAllBankContracts();
        Task<Contract> GetBankContractsFromNumber(string number);
        Task<BankContractViewModel> GetBankContractsViewModelFromNumber(string number);
    }
    public class Repository : IRepository
    {
        private readonly IConfiguration Configuration;
        string connectionString = null;
        public Repository(string connectStr, IConfiguration configuration)
        {
            connectionString = connectStr;
            Configuration = configuration;
        }
        public async Task<List<Contract>> GetAllBankContracts()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var res = await db.QueryAsync<Contract>("SELECT * FROM [ContractsBanks]");
                return res.ToList();
            }
        }
        public async Task<Contract> GetBankContractsFromNumber(string number)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return await db.QueryFirstOrDefaultAsync<Contract>($"SELECT * FROM [ContractsBanks] WHERE NumberContract = N'{number}'");                
            }
        }
        public async Task<BankContractViewModel> GetBankContractsViewModelFromNumber(string number)
        {
            BankContractViewModel viewModel = new BankContractViewModel();
            using IDbConnection db = new SqlConnection(connectionString);
            var contract = await GetBankContractsFromNumber(number);
            viewModel.BankContract = contract;
            var insServices = await GetInsuranceServicesFromContractId(contract.ContarctId);
            foreach (var item in insServices)
            {
                viewModel.InsurancesService.Add(await GetISUnitsFromISId(item.InsuranceServiceId));
            }
            return viewModel;
        }
        public async Task<List<InsuranceService>> GetInsuranceServicesFromContractId(Guid contractId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var res = await db.QueryAsync<InsuranceService>($"SELECT * FROM [InsuranceServices] WHERE ContractId = N'{contractId}'");
                return res.ToList();
            }
        }
        public async Task<InsuranceService> GetInsuranceServiceFromId(Guid ISId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return await db.QueryFirstOrDefaultAsync<InsuranceService>($"SELECT * FROM [InsuranceServices] WHERE InsuranceServiceId = CONVERT(uniqueidentifier,'{ISId}')");                
            }
        }
        public async Task<InsuranceServiceUnit> GetISUnitsFromISId(Guid ISId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var res = await db.QueryAsync<LifeCycleInsuranceService>($"SELECT * FROM [LifeCyclesIS] WHERE InsuranceServiceId = N'{ISId}'");
                return new InsuranceServiceUnit(res.ToList(), await GetInsuranceServiceFromId(ISId));                
            }            
        }
    }
}
