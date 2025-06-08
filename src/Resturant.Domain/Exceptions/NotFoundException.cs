namespace Resturant.Domain.Exceptions
{
    public class NotFoundException (string resourceType,int resourceId)
        : Exception($"{resourceType} with Id: {resourceId} doesn't exist")
    {
    }
}
