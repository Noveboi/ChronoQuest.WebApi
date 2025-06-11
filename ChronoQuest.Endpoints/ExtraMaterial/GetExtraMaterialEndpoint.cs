namespace ChronoQuest.Endpoints.ExtraMaterial;

public class GetExtraMaterialEndpoint
{
    // Two cases:
    // - Case 1: Extra material for user exists! Simply return the material as a DTO
    // - Case 2: Extra material for user does not exist! First generate the material, add it to the DB and then return 
    //           it as a DTO.
}