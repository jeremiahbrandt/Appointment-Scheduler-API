public class GetProfessionalResponse
{    
    public string FirebaseUid { get; set; } 
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string Occupation { get; set; } 
    public string ShareableCode { get; set; } 
    public int StreetNumber { get; set; } 
    public string StreetName { get; set; } 
    public string City { get; set; } 
    public string State { get; set; } 
    public int ZipCode { get; set; }
}

public class GetProfessionalTimeSlotsResponse
{    
    public string FirebaseUid { get; set; } 
    public string TimeSlotId { get; set; } 
    public string StartTime { get; set; } 
    public string EndTime { get; set; }
}

public class GetProfessionalAppointmentsResponse
{   
    public string ProfessionalUid { get; set; } 
    public string StartTime { get; set; } 
    public string EndTime { get; set; } 
    public string AppointmentName { get; set; } 
    public string AppointmentDescription { get; set; } 
    public string ClientUid { get; set; }
    public string ClientFirstName { get; set; }
    public string ClientLastName { get; set; }
}

public class GetClientResponse
{    
    public string FirebaseUid { get; set; } 
    public string FirstName { get; set; } 
    public string LastName { get; set; }
}

public class GetClientFavoritesResponse
{    
    public string ProfessionalFirebaseUid { get; set; } 
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string Occupation { get; set; } 
    public string ShareableCode { get; set; } 
    public int StreetNumber { get; set; } 
    public string StreetName { get; set; } 
    public string City { get; set; } 
    public string State { get; set; } 
    public int ZipCode { get; set; }
}

public class GetClientAppointmentsResponse
{    
    public string TimeSlotId { get; set; }
    public string AppointmentName { get; set; } 
    public string AppointmentDescription { get; set; } 
    public string StartTime { get; set; } 
    public string EndTime { get; set; } 
    public string ProfessionalFirstName { get; set; }
    public string ProfessionalLastName { get; set; } 
    public string Occupation { get; set; } 
    public string ShareableCode { get; set; } 
    public int StreetNumber { get; set; } 
    public string StreetName { get; set; } 
    public string City { get; set; } 
    public string State { get; set; } 
    public int ZipCode { get; set; }
}