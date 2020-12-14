using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.Persistence;
using Tienda.Ventas.Applicacion.Persistence.Repository;

namespace Tienda.Ventas.Applicacion.Features.Producto.InsertProducto
{
    public class InsertProductoHandler : IRequestHandler<InsertProductoCommand, VoidResult>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertProductoHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(InsertProductoCommand request, CancellationToken cancellationToken)
        {
            Ventas.Domain.Model.Ventas.Producto producto = new Domain.Model.Ventas.Producto(request.Nombre, request.Precio, request.UrlImagen, request.Categoria);
            await _productoRepository.Insert(producto);
            await _unitOfWork.Commit(cancellationToken);
            return new VoidResult();
        }
    }
}
