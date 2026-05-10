using AutoMapper;
using BLL.DTO.Device;
using BLL.DTO.Extra;
using BLL.DTO.Invoice;
using BLL.DTO.Product;
using BLL.DTO.Services.Repair;
using BLL.DTO.Services.Service;
using BLL.DTO.Users.Customer;
using BLL.DTO.Users.Login;
using BLL.DTO.Users.User;
using Entities.Elements;
using Entities.Elements.Enums;
using Entities.Elements.InvoiceFolder;
using Entities.Elements.ProductFolder;
using Entities.Extra;
using Entities.Services;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            //--------------------------------- USER ---------------------
            CreateMap<User, UserResponseDTO>().ReverseMap();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserBaseDTO>().ReverseMap();
            //------------------------------------------------------------

            //--------------------------------- LOGIN ---------------------
            CreateMap<User, LoginRequestDTO>().ReverseMap();
            CreateMap<User, RegisterRequestDTO>().ReverseMap();
            //------------------------------------------------------------

            //--------------------------------- CUSTOMER -----------------
            CreateMap<Customer, CustomerResponseDTO>().ReverseMap();
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<Customer, CustomerBaseDTO>().ReverseMap();
            //------------------------------------------------------------

            //--------------------------------- REPAIR -------------------
            CreateMap<Repair, RepairResponseDTO>().ReverseMap();

            CreateMap<RepairCreateDTO, Repair>()
                .ForPath(dest => dest.DeviceId, opt => opt.MapFrom(src => src.DeviceId))
                .ForPath(dest => dest.Device.Type, opt => opt.MapFrom(src => src.DeviceType))
                .ForPath(dest => dest.Device.Brand, opt => opt.MapFrom(src => src.DeviceBrand))
                .ForPath(dest => dest.Device.Model, opt => opt.MapFrom(src => src.DeviceModel))
                .ForPath(dest => dest.Device.SerialNumber, opt => opt.MapFrom(src => src.DeviceSerialNumber))
                .ForPath(dest => dest.Device.Owner.Id, opt => opt.MapFrom(src => src.OwnerId))
                .ForPath(dest => dest.Device.Owner.Name, opt => opt.MapFrom(src => src.OwnerName));

            CreateMap<RepairUpdateDTO, Repair>();
            //------------------------------------------------------------

            //--------------------------------- SERVICE -----------------
            CreateMap<Service, ServiceResponseDTO>().ReverseMap();
            CreateMap<ServiceCreateDTO, Service>().ReverseMap();
            CreateMap<ServiceUpdateDTO, Service>().ReverseMap();
            //------------------------------------------------------------

            //--------------------------------- PRODUCT -----------------
            CreateMap<Product, ProductResponseDTO>().ReverseMap()
                .ForPath(dest => dest.Category.Description, opt => opt.MapFrom(src => src.CategoryDescription))
                .ForPath(dest => dest.Details.Description, opt => opt.MapFrom(src => src.DetailsDescription));

            CreateMap<Product, ProductResponseDTO>()
                .ForMember(dest => dest.BarCode, opt => opt.MapFrom(src => src.Details.BarCode))
                .ForMember(dest => dest.PurchasePrice, opt => opt.MapFrom(src => src.Details.PurchasePrice));

            CreateMap<ProductResponseDTO, Product>()
                .ForPath(dest => dest.Details.BarCode, opt => opt.MapFrom(src => src.BarCode))
                .ForPath(dest => dest.Details.PurchasePrice, opt => opt.MapFrom(src => src.PurchasePrice));

            CreateMap<ProductCreateDTO, Product>()
                .ForPath(dest => dest.Category.Description, opt => opt.MapFrom(src => src.CategoryDescription))
                .ForPath(dest => dest.Details.Description, opt => opt.MapFrom(src => src.DetailsDescription))
                .ForPath(dest => dest.Details.BarCode, opt => opt.MapFrom(src => src.BarCode))
                .ForPath(dest => dest.Details.PurchasePrice, opt => opt.MapFrom(src => src.PurchasePrice));

            CreateMap<ProductUpdateDTO, Product>()
                .ForPath(dest => dest.Category.Description, opt => opt.MapFrom(src => src.CategoryDescription))
                .ForPath(dest => dest.Details.Description, opt => opt.MapFrom(src => src.DetailsDescription))
                .ForPath(dest => dest.Details.BarCode, opt => opt.MapFrom(src => src.BarCode));

            CreateMap<Product, ProductBaseDTO>().ReverseMap()
                .ForPath(dest => dest.Category.Description, opt => opt.MapFrom(src => src.CategoryDescription))
                .ForPath(dest => dest.Details.Description, opt => opt.MapFrom(src => src.DetailsDescription))
                .ForPath(dest => dest.Details.BarCode, opt => opt.MapFrom(src => src.BarCode));
            //------------------------------------------------------------

            //--------------------------------- INVOICE -----------------
            CreateMap<Invoice, InvoiceResponseDTO>().ReverseMap()
                .ForPath(dest => dest.Details.PercentageDiscount, opt => opt.MapFrom(src => src.PercentageDiscount))
                .ForPath(dest => dest.Details.PercentageTax, opt => opt.MapFrom(src => src.PercentageTax))
                .ForPath(dest => dest.Details.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForPath(dest => dest.Details.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<InvoiceCreateDTO, Invoice>();
            CreateMap<InvoiceUpdateDTO, Invoice>();

            CreateMap<InvoiceItem, InvoiceItemDTO>().ReverseMap()
                .ForPath(dest => dest.Product.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForPath(dest => dest.Product.SalePrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForPath(dest => dest.Invoice.Details.Quantity, opt => opt.MapFrom(src => src.Quantity));
            //------------------------------------------------------------

            //--------------------------------- STOCK MOVEMENT ----------
            CreateMap<StockMovement, StockMovementResponseDTO>().ReverseMap()
                .ForPath(dest => dest.Invoice.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber));

            CreateMap<StockMovementItem, StockMovementItemDTO>().ReverseMap()
                .ForPath(dest => dest.Product.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForPath(dest => dest.Product.Id, opt => opt.MapFrom(src => src.ProductId));
            //------------------------------------------------------------

            //--------------------------------- DEVICE ------------------
            CreateMap<Device, BaseDeviceDTO>().ReverseMap();
            CreateMap<DeviceCreateDTO, Device>();
            CreateMap<DeviceResponseDTO, Device>().ReverseMap();
            //------------------------------------------------------------
        }
    }
}
