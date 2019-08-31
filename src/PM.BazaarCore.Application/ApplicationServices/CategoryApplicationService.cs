using Microsoft.EntityFrameworkCore;
using PM.BazaarCore.Application.ApplicationServices.Common;
using PM.BazaarCore.Application.Interfaces;
using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Application.ApplicationServices
{
    public class CategoryApplicationService : ApplicationService, ICategoryApplicationService
    {
        private readonly ICategoryService _service;
        private bool _disposed;

        public CategoryApplicationService(ICategoryService service, IUoW uow, CancellationToken cancellationToken) : base(uow, cancellationToken)
        {
            _service = service;
        }

        public CategoryApplicationService(ICategoryService service, IUoW uow) : base(uow, CancellationToken.None) { }

        public IEnumerable<Category> AllCategories()
        {
            return _service.Set().ToList();
        }

        public async Task<IEnumerable<Category>> AllCategoriesAsync()
        {
            return (await _service.Set().ToListAsync(CancellationToken));
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)            
                _service.Dispose();                

            _disposed = true;

            base.Dispose(disposing);
        }
    }
}
