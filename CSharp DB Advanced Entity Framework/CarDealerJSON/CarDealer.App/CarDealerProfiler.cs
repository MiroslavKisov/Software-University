namespace CarDealer.App
{
    using AutoMapper;
    using CarDealer.App.Dto;
    using CarDealer.Models;

    public class CarDealerProfiler : Profile
    {
        public CarDealerProfiler()
        {
            CreateMap<SupplierDto, Supplier>();
            CreateMap<SupplierExportDto, Supplier>();
            CreateMap<PartDto, Part>();
            CreateMap<PartExportDto, Part>();
            CreateMap<CarDto, Car>();
            CreateMap<CarExportDto, Car>();
            CreateMap<CarWithPartsExportDto, Car>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<CustomerExportDto, Customer>();
            CreateMap<CustomerWithTotalSalesExport, Customer>();
            CreateMap<SaleCustomerDto, Customer>();
            CreateMap<SaleCarDto, Car>();
        }
    }
}
