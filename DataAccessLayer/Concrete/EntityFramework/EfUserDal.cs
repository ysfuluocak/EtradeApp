using Core.DataAccessLayer.Concrete.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, EtradeContext>, IUserDal
    {
        public List<OperationClaim> GetOperationClaims(User user)
        {
            using (var context = new EtradeContext())
            {
                var result = from uop in context.Set<UserOperationClaim>()
                             join op in context.OperationClaims
                             on uop.OperationClaimId equals op.Id
                             where uop.Id == user.Id
                             select op;
                return result.ToList();
                         
            }
        }

    }
}
