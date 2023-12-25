using Microsoft.EntityFrameworkCore;
using Rent.BL.Property.DTO;
using Rent.DAL;
using Rent.Domain.Entities.Properties;
using Rent.Domain.Exceptions.Properties;
using Rent.FileManager;

namespace Rent.BL.Property;

public class PropertyService : IPropertyService
{
    private readonly RentDbContext _context;
    private readonly IFileManager _fileManager;

    public PropertyService(RentDbContext context, IFileManager fileManager)
    {
        _context = context;
        _fileManager = fileManager;
    }

    public IEnumerable<Domain.Entities.Properties.Property> GetUserProperties(Guid userId)
    {
        var properties = _context.Properties.Where(p => p.OwnerId == userId).ToList();
        return properties;
    }

    public void DeleteProperty(int propertyId, Guid userId)
    {
        var property = _context.Properties.FirstOrDefault(p => p.Id == propertyId);
        if (property == null)
        {
            throw new PropertyNotFoundException(propertyId);
        }

        if (property.OwnerId != userId)
        {
            throw new UserNotOwnerOfPropertyException(propertyId);
        }
        _context.Properties.Remove(property);
        _context.SaveChanges();
    }

    public PropertySearchResult Search(SearchPropertiesFilters filters)
    {
        var result = new PropertySearchResult();
        var propertiesQuery = _context.Properties.Where(p => p.Country.ToLower().Contains(filters.Country));
        if (filters.City != null)
        {
            propertiesQuery = propertiesQuery.Where(p => p.City.ToLower().Contains(filters.City));
        }
        if (filters.State != null)
        {
            propertiesQuery = propertiesQuery.Where(p => p.State != null && p.State.ToLower().Contains(filters.State));
        }

        result.Total = propertiesQuery.Count();
        var properties = propertiesQuery.OrderBy(p => p.Id).Skip(filters.PageSize * filters.Page).Take(filters.PageSize).ToList();
        result.Properties = properties;
        return result;
    }

    public Domain.Entities.Properties.Property GetProperty(int id)
    {
        var property = _context.Properties.Include(p => p.Images).FirstOrDefault(p => p.Id == id);
        if (property == null)
        {
            throw new PropertyNotFoundException(id);
        }
        return property;
    }

    public void AddPropertyImage(int propertyId, string extension, Stream stream)
    {
        var propertyImageId = Guid.NewGuid();
        var key = $"properties/{propertyId}/{propertyImageId}{extension}";
        _fileManager.UploadFile(key, stream);
        var propertyImage = new PropertyImage
        {
            Id = propertyImageId,
            PropertyId = propertyId,
            Extension = extension
        };
        _context.PropertyImages.Add(propertyImage);
        _context.SaveChanges();
    }

    public IEnumerable<PropertyImage> GetPropertyImages(int propertyId)
    {
        var images = _context.PropertyImages.Where(i => i.PropertyId == propertyId).ToList();
        return images;
    }

    public string GetPropertyImageUrl(PropertyImage propertyImage)
    {
        var key = $"properties/{propertyImage.PropertyId}/{propertyImage.Id}{propertyImage.Extension}";
        var url = _fileManager.GetFileCDN(key);
        return url;
    }
}