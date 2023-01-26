using Core.DataAccessLayer.Concrete.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, EtradeContext>, IOperationClaimDal
    {
        
    }
}
