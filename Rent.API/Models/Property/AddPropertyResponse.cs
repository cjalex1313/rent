using Rent.API.Models.Base;

namespace Rent.API.Models.Property;

public class AddPropertyResponse : BaseResponse
{
    public int Id { get; set; }
    
    public AddPropertyResponse(int id)
    {
        this.Id = id;
        this.Succeeded = true;
        this.Error = null;
        this.Errors = null;
    }
}