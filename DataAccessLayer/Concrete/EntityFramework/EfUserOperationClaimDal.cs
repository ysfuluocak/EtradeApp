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
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim,EtradeContext>,IUserOperationClaimDal
    {
    }
}
