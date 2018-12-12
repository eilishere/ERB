namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ResumeBank.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<ResumeBank.Repository.RBDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ResumeBank.Repository.RBDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Genders.AddOrUpdate(g => g.Id,
                new Gender() { Id = 2, Name = "Male" },
                new Gender() { Id = 1, Name = "Female" }
                );

            context.Categories.AddOrUpdate(c => c.Id,
                new Category() { Id = 1, Name = "Accounting/Finance", UpdatedAt = DateTime.Today },
                new Category() { Id = 2, Name = "Agro", UpdatedAt = DateTime.Today },
                new Category() { Id = 3, Name = "Bank/ Non-Bank Fin. Institution", ParentId = 1, UpdatedAt = DateTime.Today },
                new Category() { Id = 4, Name = "Beauty Care/ Health & Fitness", ParentId = 27, UpdatedAt = DateTime.Today },
                new Category() { Id = 5, Name = "Commercial/Supply Chain", ParentId = 19, UpdatedAt = DateTime.Today },
                new Category() { Id = 6, Name = "Customer Support/Call Centre", ParentId = 27, UpdatedAt = DateTime.Today },
                new Category() { Id = 7, Name = "Data Entry/Operator/BPO", ParentId = 27, UpdatedAt = DateTime.Today },
                new Category() { Id = 8, Name = "Design/Creative", ParentId = 12, UpdatedAt = DateTime.Today },
                new Category() { Id = 9, Name = "Driving/Motor Technician", ParentId = 27, UpdatedAt = DateTime.Today },
                new Category() { Id = 10, Name = "Education/Training", UpdatedAt = DateTime.Today },
                new Category() { Id = 11, Name = "Electrician/ Construction/ Repair", ParentId = 12, UpdatedAt = DateTime.Today },
                new Category() { Id = 12, Name = "Engineer/Architects", UpdatedAt = DateTime.Today },
                new Category() { Id = 13, Name = "Garments/Textile", ParentId = 12, UpdatedAt = DateTime.Today },
                new Category() { Id = 14, Name = "Gen Mgt/Admin", UpdatedAt = DateTime.Today },
                new Category() { Id = 15, Name = "Hospitality/ Travel/ Tourism",  ParentId = 27, UpdatedAt = DateTime.Today },
                new Category() { Id = 16, Name = "HR/Org. Development", UpdatedAt = DateTime.Today },
                new Category() { Id = 17, Name = "IT & Telecommunication", UpdatedAt = DateTime.Today },
                new Category() { Id = 18, Name = "Law/Legal", UpdatedAt = DateTime.Today },
                new Category() { Id = 19, Name = "Marketing/Sales", UpdatedAt = DateTime.Today },
                new Category() { Id = 20, Name = "Media/Ad./Event Mgt.", UpdatedAt = DateTime.Today },
                new Category() { Id = 21, Name = "Medical/Pharma", UpdatedAt = DateTime.Today },
                new Category() { Id = 22, Name = "NGO/Development", UpdatedAt = DateTime.Today },
                new Category() { Id = 23, Name = "Production/Operation", ParentId = 27, UpdatedAt = DateTime.Today },
                new Category() { Id = 24, Name = "Research/Consultancy", UpdatedAt = DateTime.Today },
                new Category() { Id = 25, Name = "Secretary/Receptionist", ParentId = 27, UpdatedAt = DateTime.Today },
                new Category() { Id = 26, Name = "Security/Support Service", ParentId = 17, UpdatedAt = DateTime.Today },
                new Category() { Id = 27, Name = "Others", UpdatedAt = DateTime.Today }
                );

            context.EducationLevels.AddOrUpdate(e => e.Id,
                new EducationLevel() { Id = 1, Name = "Doctorate", UpdatedAt = DateTime.Today },
                new EducationLevel() { Id = 2, Name = "Masters", UpdatedAt = DateTime.Today },
                new EducationLevel() { Id = 3, Name = "Bachelor", UpdatedAt = DateTime.Today },
                new EducationLevel() { Id = 4, Name = "Diploma", UpdatedAt = DateTime.Today },
                new EducationLevel() { Id = 5, Name = "HSC", UpdatedAt = DateTime.Today },
                new EducationLevel() { Id = 6, Name = "SSC", UpdatedAt = DateTime.Today }
                );

            context.InstituteTypes.AddOrUpdate(i => i.Id,
                new InstituteType() { Id = 1, Name = "Public", UpdatedAt = DateTime.Today },
                new InstituteType() { Id = 2, Name = "Private", UpdatedAt = DateTime.Today },
                new InstituteType() { Id = 3, Name = "Foreign", UpdatedAt = DateTime.Today }
                );

            context.Institutes.AddOrUpdate(i => i.Id,
                new Institute() { Id = 1, Name = "Ahsanullah University of Science and Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 2, Name = "American International University Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 3, Name = "Anwer Khan Modern University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 4, Name = "Army University of Engineering and Technology (BAUET), Qadirabad", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 5, Name = "Army University of Science and Technology(BAUST), Saidpur", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 6, Name = "ASA University Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 7, Name = "Asian University of Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 8, Name = "Atish Dipankar University of Science & Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 9, Name = "Bangabandhu Sheikh Mujib Medical University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 10, Name = "Bangabandhu Sheikh Mujibur Rahman Agricultural University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 11, Name = "Bangabandhu Sheikh Mujibur Rahman Maritime University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 12, Name = "Bangabandhu Sheikh Mujibur Rahman Science & Technology University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 13, Name = "Bangladesh Agricultural University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 14, Name = "Bangladesh Army International University of Science & Technology, Comilla", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 15, Name = "Bangladesh Islami University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 16, Name = "Bangladesh Open University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 17, Name = "Bangladesh University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 18, Name = "Bangladesh University of Business & Technology (BUBT)", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 19, Name = "Bangladesh University of Engineering & Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 20, Name = "Bangladesh University of Health Sciences", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 21, Name = "Bangladesh University of Professionals", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 22, Name = "Bangladesh University of Textiles", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 23, Name = "Barisal University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 24, Name = "Begum Rokeya University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 25, Name = "BGC Trust University Bangladesh, Chittagong", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 26, Name = "BGMEA University of Fashion & Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 27, Name = "BRAC University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 28, Name = "Britannia University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 29, Name = "Canadian University of Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 30, Name = "CCN University of Science & Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 31, Name = "Central University of Science and Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 32, Name = "Central Women’s University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 33, Name = "Chittagong Independent University (CIU)", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 34, Name = "Chittagong Medical University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 35, Name = "Chittagong University of Engineering & Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 36, Name = "Chittagong Veterinary and Animal Sciences University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 37, Name = "City University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 38, Name = "Comilla University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 39, Name = "Coxs Bazar International University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 40, Name = "Daffodil International University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 41, Name = "Dhaka International University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 42, Name = "Dhaka University of Engineering & Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 43, Name = "East Delta University , Chittagong", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 44, Name = "East West University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 45, Name = "Eastern University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 46, Name = "European University of Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 47, Name = "Exim Bank Agricultural University, Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 48, Name = "Fareast International University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 49, Name = "Feni University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 50, Name = "First Capital University of Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 51, Name = "German University Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 52, Name = "Global University Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 53, Name = "Gono Bishwabidyalay", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 54, Name = "Green University of Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 55, Name = "Hajee Mohammad Danesh Science & Technology University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 56, Name = "Hamdard University Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 57, Name = "IBAIS University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 58, Name = "Independent University, Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 59, Name = "International Islamic University, Chittagong", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 60, Name = "International University of Business Agriculture & Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 61, Name = "Ishakha International University, Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 62, Name = "Islamic Arabic University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 63, Name = "Islamic University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 64, Name = "Jagannath University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 65, Name = "Jahangirnagar University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 66, Name = "Jatiya Kabi Kazi Nazrul Islam University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 67, Name = "Jessore University of Science & Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 68, Name = "Khulna University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 69, Name = "Khulna University of Engineering and Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 70, Name = "Khwaja Yunus Ali University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 71, Name = "Leading University, Sylhet", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 72, Name = "Manarat International University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 73, Name = "Mawlana Bhashani Science & Technology University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 74, Name = "Metropolitan University, Sylhet", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 75, Name = "N.P.I University of Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 76, Name = "National University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 77, Name = "Noakhali Science & Technology University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 78, Name = "North Bengal International University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 79, Name = "North East University Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 80, Name = "North South University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 81, Name = "North Western University, Khulna", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 82, Name = "Northern University Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 83, Name = "Northern University of Business & Technology, Khulna", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 84, Name = "Notre Dame University Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 85, Name = "Pabna University of Science and Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 86, Name = "Patuakhali Science And Technology University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 87, Name = "Port City International University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 88, Name = "Premier University, Chittagong", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 89, Name = "Presidency University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 90, Name = "Prime University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 91, Name = "Primeasia University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 92, Name = "Pundro University of Science & Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 93, Name = "Queens University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 94, Name = "Rabindra Moitri University, Kushtia", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 95, Name = "Rajshahi Medical University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 96, Name = "Rajshahi Science & Technology University (RSTU), Natore", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 97, Name = "Rajshahi University of Engineering & Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 98, Name = "Ranada Prasad Shaha University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 99, Name = "Rangamati Science and Technology University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 100, Name = "Royal University of Dhaka", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 101, Name = "Shahjalal University of Science & Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 102, Name = "Shanto Mariam University of Creative Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 103, Name = "Sheikh Fazilatunnesa Mujib University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 104, Name = "Sher-e-Bangla Agricultural University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 105, Name = "Sonargaon University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 106, Name = "Southeast University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 107, Name = "Southern University Bangladesh , Chittagong", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 108, Name = "Stamford University, Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 109, Name = "State University Of Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 110, Name = "Sylhet Agricultural University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 111, Name = "Sylhet International University, Sylhet", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 112, Name = "The International University of Scholars", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 113, Name = "The Millennium University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 114, Name = "The Peoples University of Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 115, Name = "The University of Asia Pacific", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 116, Name = "Times University Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 117, Name = "United International University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 118, Name = "University of Chittagong", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 119, Name = "University of Creative Technology, Chittagong", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 120, Name = "University of Development Alternative", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 121, Name = "University of Dhaka", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 122, Name = "University of Global Village", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 123, Name = "University of Information Technology & Sciences", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 124, Name = "University of Liberal Arts Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 125, Name = "University of Rajshahi", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 126, Name = "University of Science & Technology, Chittagong", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 127, Name = "University of South Asia", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 128, Name = "Uttara University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 129, Name = "Varendra University", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 130, Name = "Victoria University of Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 131, Name = "World University of Bangladesh", UpdatedAt = DateTime.Today, InstituteTypeId = 1 },
                new Institute() { Id = 132, Name = "Z.H Sikder University of Science & Technology", UpdatedAt = DateTime.Today, InstituteTypeId = 1 }
                );

            context.JobLevels.AddOrUpdate(j => j.Id,
                new JobLevel() { Id = 1, Name = "Entry Level", UpdatedAt = DateTime.Today },
                new JobLevel() { Id = 2, Name = "Mid Level", UpdatedAt = DateTime.Today },
                new JobLevel() { Id = 3, Name = "Top Level", UpdatedAt = DateTime.Today }
                );

            context.Subjects.AddOrUpdate(s => s.Id, 
                new Subject() { Id = 1, Name = "BBA", UpdatedAt = DateTime.Today },
                new Subject() { Id = 2, Name = "EEE", UpdatedAt = DateTime.Today },
                new Subject() { Id = 3, Name = "CS", UpdatedAt = DateTime.Today },
                new Subject() { Id = 4, Name = "Accouting", UpdatedAt = DateTime.Today },
                new Subject() { Id = 5, Name = "Marketing", UpdatedAt = DateTime.Today },
                new Subject() { Id = 6, Name = "Management", UpdatedAt = DateTime.Today },
                new Subject() { Id = 7, Name = "Economics", UpdatedAt = DateTime.Today },
                new Subject() { Id = 8, Name = "Finance", UpdatedAt = DateTime.Today },
                new Subject() { Id = 9, Name = "Law", UpdatedAt = DateTime.Today },
                new Subject() { Id = 10, Name = "Social Science", UpdatedAt = DateTime.Today }
                );
        }
    }
}
