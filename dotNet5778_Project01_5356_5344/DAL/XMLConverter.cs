using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
namespace DAL
{
    public static class XMLConverter
    {
        /// <summary>
        /// turns a nanny class type into a XML type
        /// </summary>
        /// <param name="nanny"></param>
        /// <returns></returns>
        public static XElement toXML(this Nanny nanny)
        {
            return new XElement("Nanny",
                 new XElement("id", nanny.id),
                 new XElement("familyName", nanny.familyName),
                 new XElement("firstName", nanny.firstName),
                 new XElement("birthday", nanny.birthday),
                 new XElement("phoneNumber", nanny.phoneNumber),
                 new XElement("address", nanny.address),
                 new XElement("hasElevator", nanny.hasElevator),
                 new XElement("floorNumber", nanny.floorNumber),
                 new XElement("seniority", nanny.seniority),
                 new XElement("maxOfKids", nanny.maxOfKids),
                 new XElement("minAgeOfKid", nanny.minAgeOfKid),
                 new XElement("maxAgeOfKid", nanny.maxAgeOfKid),
                 new XElement("doesWorkPerHour", nanny.doesWorkPerHour),
                 new XElement("hourWage", nanny.hourWage),
                 new XElement("monthlyWage", nanny.monthlyWage),

                new XElement("daysOfWork",
                    (from d in nanny.daysOfWork
                     select new XElement("Days", d.ToString())
                         )),
                    (from d in nanny.hoursOfWork
                     select new XElement("Day",
                     new XElement(d.toXML())
                     )),
                    new XElement("hasGovVacationDays", nanny.hasGovVacationDays),
                     new XElement("Recommendations", nanny.Recommendations),
                      new XElement("numberOfSignedContracts", nanny.numberOfSignedContracts)
                               );
        }

        /// <summary>
        /// turns a mother class type into XML type
        /// </summary>
        /// <param name="mother"></param>
        /// <returns></returns>
        public static XElement toXML(this Mother mother)
        {
            return new XElement("Mother",
                new XElement("id", mother.id),
                new XElement("familyName", mother.familyName),
                new XElement("firstName", mother.firstName),

                new XElement("address", mother.address),
                new XElement("addressRadius", mother.addressRadius),
                new XElement("wantsATrialMeeting", mother.wantsATrialMeeting),
                new XElement("comments", mother.comments),

                new XElement("daysOfNannyArray",
                    (from d in mother.daysOfNanny
                     select new XElement("Days", d.ToString())
                    )),
                    (from d in mother.hoursByNanny
                     select new XElement("Day",
                     new XElement(d.toXML())
                     ))
            );
        }



        public static XElement toXML(this Child child)
        {
            return new XElement("Child",
                new XElement("id", child.id),
                new XElement("name", child.name),
                new XElement("momsId", child.momsId),
                new XElement("birthday", child.birthday),
                new XElement("hasSpecialNeeds", child.hasSpecialNeeds),
                new XElement("specialNeeds", child.specialNeeds)
                );
        }

        /// <summary>
        /// turns a contract type into a XML type
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public static XElement toXML(this Contract contract)
        {
            return new XElement("Contract",
                new XElement("numberOfContract", contract.numberOfContract),
                new XElement("NannysId", contract.NannysId),
                new XElement("childId", contract.childId),
                new XElement("isSingedContract", contract.isSingedContract),
                new XElement("moneyPerHour", contract.moneyPerHour),
                new XElement("monthSalary", contract.monthSalary),
                new XElement("isMonthContract", contract.isMonthContract),
                new XElement("StartDate", contract.StartDate),
                new XElement("ExpirationDate", contract.ExpirationDate)
          );
        }

        /// <summary>
        /// turns a Day class type to a XML type
        /// </summary>
        /// <param name="day"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static XElement toXML(this Day day, string attribute = "undefined")
        {
            return new XElement("Day",
                new XElement("start_hour", day.start_hour),
                new XElement("start_minute", day.start_minute),
                new XElement("finish_hour ", day.finish_hour),
                new XElement("finish_minute", day.finish_minute));
        }

        public static Nanny toNanny(this XElement NannyXml)
        {
            Nanny nanny = null;

            if (NannyXml != null)
            {
                nanny = new Nanny
                {
                    id = Int32.Parse(NannyXml.Element("id").Value),
                    firstName = NannyXml.Element("firstName").Value,
                    familyName = NannyXml.Element("familyName").Value,
                    phoneNumber = NannyXml.Element("phoneNumber").Value,
                    birthday = DateTime.Parse(NannyXml.Element("birthday").Value),
                    address = NannyXml.Element("address").Value,
                    hasElevator = Boolean.Parse(NannyXml.Element("hasElevator").Value),
                    floorNumber = Int32.Parse(NannyXml.Element("floorNumber").Value),
                    seniority = Int32.Parse(NannyXml.Element("seniority").Value),
                    maxOfKids = Int32.Parse(NannyXml.Element("maxOfKids").Value),
                    minAgeOfKid = Int32.Parse(NannyXml.Element("minAgeOfKid").Value),
                    maxAgeOfKid = Int32.Parse(NannyXml.Element("maxAgeOfKid ").Value),
                    doesWorkPerHour = Boolean.Parse(NannyXml.Element("doesWorkPerHour").Value),
                    hourWage = Int32.Parse(NannyXml.Element(" hourWage").Value),
                    monthlyWage = Int32.Parse(NannyXml.Element("monthlyWage").Value),
                    daysOfWork = null,
                    hoursOfWork = null,
                    hasGovVacationDays = Boolean.Parse(NannyXml.Element("hasGovVacationDays").Value),
                    Recommendations = NannyXml.Element("Recommendations").Value,
                    numberOfSignedContracts = Int32.Parse(NannyXml.Element("numberOfSignedContracts ").Value),


                };
            }
            return nanny;
        }

        public static Mother toMother(this XElement motherXml)
        {
            Mother mother = null;

            if (motherXml != null)
            {
                mother = new Mother
                {
                    id = Int32.Parse(motherXml.Element("id").Value),
                    firstName = motherXml.Element("firstName").Value,
                    familyName = motherXml.Element("familyName").Value,
                    phoneNumber = motherXml.Element("phoneNumber").Value,
                    address = motherXml.Element("address").Value,
                    addressRadius = Int32.Parse(motherXml.Element("addressRadius").Value),
                    wantsATrialMeeting = Boolean.Parse(motherXml.Element("wantsATrialMeeting").Value),
                    comments = motherXml.Element("comments").Value,
                    daysOfNanny = (from e in motherXml.Element("daysOfNannyArray").Elements("Days")
                                   select Boolean.Parse(e.Value)).ToArray(),
                    /* hoursByNanny = (from d in motherXml.Element("hoursByNanny").Elements("Day")
                                     select new Day
                                     {
                                         start_hour = Int32.Parse(motherXml.Element("start_our").Value),
                                         start_minute = Int32.Parse(motherXml.Element("start_minute").Value),
                                         finish_hour = Int32.Parse(motherXml.Element("finish_hour").Value),
                                         finish_minute = Int32.Parse(d.Element("finish_minute").Value),
                                     }).ToList()
                                     */
                };

            }
            return mother;
        }


    }
}
