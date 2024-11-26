using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class AccountDAO : GenericDAO<AccountDAO>
    {
        public AccountMember GetAccountById(string accountID)
        {
            AccountMember accountMember = new AccountMember();
            if (accountID.Equals("PS0001"))
            {
                accountMember.MemberId = accountID;
                accountMember.MemberPassword = "@1";
                accountMember.MemberRole = 1;
            }
            return accountMember;
        }
    }
}
