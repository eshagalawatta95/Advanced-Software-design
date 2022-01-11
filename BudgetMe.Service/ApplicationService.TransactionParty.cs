using BudgetMe.Entities;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

namespace BudgetMe.Service
{
    public partial class ApplicationService
    {
        public async Task<TransactionPartyEntity> InsertTransactionPartyAsync(TransactionPartyEntity transactionParty)
        {
            if (IsTransactionPartyCodeUsed(transactionParty.Code))
            {
                throw new Exception("Transaction Party already used");
            }

            int tpId = await _transactionPartyModel.InsertTransactionPartyAsync(transactionParty);
            transactionParty = await _transactionPartyModel.GetTransactionPartyByIdAsync(tpId);

            IList<TransactionPartyEntity> transactionParties = TransactionParties.ToList();
            transactionParties.Add(transactionParty);
            TransactionParties = transactionParties;

            return transactionParty;
        }

        public bool IsTransactionPartyCodeUsed(string code) =>
            TransactionParties.Any(tp => tp.Code?.ToUpper() == code?.ToUpper());

        public bool IsTransactionPartyCodeUsedWithoutCurrent(string code, int currentId) =>
            TransactionParties.Any(tp => tp.Code?.ToUpper() == code?.ToUpper() && tp.Id != currentId);

        public async Task<TransactionPartyEntity> UpdateTransactionPartyAsync(TransactionPartyEntity transactionParty)
        {
            if (IsTransactionPartyCodeUsedWithoutCurrent(transactionParty.Code, transactionParty.Id))
            {
                throw new Exception("Transaction Party already used");
            }

            await _transactionPartyModel.UpdateTransactionPartyAsync(transactionParty);
            transactionParty = await _transactionPartyModel.GetTransactionPartyByIdAsync(transactionParty.Id);

            IEnumerable<TransactionPartyEntity> transactionParties = await _transactionPartyModel.GetTransactionPartiesAsync();
            TransactionParties = transactionParties;

            return transactionParty;
        }

        public async Task DeleteTransactionPartyAsync(int id)
        {
            await _transactionPartyModel.DeleteTransactionPartyAsync(id);

            IList<TransactionPartyEntity> transactionParties = TransactionParties.ToList();
            TransactionPartyEntity transactionParty = transactionParties.First(tp => tp.Id == id);
            transactionParty.IsActive = false;
            TransactionParties = transactionParties;
        }
    }
}
