using AutoMapper;
using BLL.DTO.Device;
using BLL.DTO.Extra;
using BLL.DTO.Invoice;
using BLL.DTO.Product;
using BLL.DTO.Services.Repair;
using BLL.DTO.Services.Service;
using BLL.DTO.Users.Customer;
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

            //--------------------------------- CUSTOMER -----------------
            CreateMap<Customer, DeviceResponseDTO>().ReverseMap();

            CreateMap<DeviceCreateDTO, Customer>();

            CreateMap<Customer, CustomerBaseDTO>().ReverseMap();

            //--------------------------------- REPAIR -------------------
            CreateMap<Repair, RepairResponseDTO>().ReverseMap();

            CreateMap<RepairCreateDTO, Repair>() /*MAAAL*/
                .ForMember(dest => dest.Device, opt => opt.MapFrom(src => new Device
                {
                    Id = src.DeviceId,
                    Type = src.DeviceType,
                    Brand = src.DeviceBrand,
                    Model = src.DeviceModel,
                    SerialNumber = src.DeviceSerialNumber,
                    Owner = new Customer { Id = src.OwnerId, Name = src.OwnerName }
                }));

            CreateMap<RepairUpdateDTO, Repair>();

            //--------------------------------- SERVICE -----------------
            CreateMap<Service, ServiceBaseDTO>().ReverseMap();

            //--------------------------------- PRODUCT -----------------
            CreateMap<Product, ProductResponseDTO>().ReverseMap();

            CreateMap<CreateProductDTO, Product>()
                .ForMember(dest => dest.Category.Description, opt => opt.MapFrom(src => src.CategoryDescription))
                .ForMember(dest => dest.Details.Description, opt => opt.MapFrom(src => src.DetailsDescription));

            CreateMap<UpdateProductDTO, Product>()
                .ForMember(dest => dest.Category.Description, opt => opt.MapFrom(src => src.CategoryDescription))
                .ForMember(dest => dest.Details.Description, opt => opt.MapFrom(src => src.DetailsDescription));

            CreateMap<Product, ProductBaseDTO>().ReverseMap()
                .ForMember(dest => dest.Category.Description, opt => opt.MapFrom(src => src.CategoryDescription))
                .ForMember(dest => dest.Details.Description, opt => opt.MapFrom(src => src.DetailsDescription));

            //--------------------------------- INVOICE -----------------
            CreateMap<Invoice, InvoiceResponseDTO>().ReverseMap()
                .ForMember(dest => dest.Details.PercentageDiscount, opt => opt.MapFrom(src => src.PercentageDiscount))
                .ForMember(dest => dest.Details.PercentageTax, opt => opt.MapFrom(src => src.PercentageTax))
                .ForMember(dest => dest.Details.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.Details.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<InvoiceCreateDTO, Invoice>();
            CreateMap<InvoiceUpdateDTO, Invoice>();

            CreateMap<InvoiceItem, InvoiceItemDTO>().ReverseMap()
                .ForMember(dest => dest.Product.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Product.SalePrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.Invoice.Details.Quantity, opt => opt.MapFrom(src => src.Quantity));

            //--------------------------------- STOCK MOVEMENT ----------
            CreateMap<StockMovement, StockMovementResponseDTO>().ReverseMap()
                .ForMember(dest => dest.Invoice.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber));

            CreateMap<StockMovementItem, StockMovementItemDTO>().ReverseMap()
                .ForMember(dest => dest.Product.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Product.Id, opt => opt.MapFrom(src => src.ProductId));

            //--------------------------------- DEVICE ------------------
            CreateMap<Device, BaseDeviceDTO>().ReverseMap();
        }
    }
}
