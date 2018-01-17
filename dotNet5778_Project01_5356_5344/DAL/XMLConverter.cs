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
                  new XElement("hoursOfWork",
                  (from d in nanny.hoursOfWork
                   select new XElement(d.toXML())
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
                new XElement("phoneNumber", mother.phoneNumber),
                new XElement("address", mother.address),
                new XElement("addressRadius", mother.addressRadius),
                new XElement("wantsATrialMeeting", mother.wantsATrialMeeting),
                new XElement("comments", mother.comments),

                new XElement("daysOfNanny",
                    (from d in mother.daysOfNanny
                     select new XElement("Days", d.ToString())
                    )),

                   new XElement("hoursByNanny",
                   (from d in mother.hoursByNanny
                    select new XElement(d.toXML())
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
                new XElement("ExpirationDate", contract.ExpirationDate),
                new XElement("Distance", contract.Distance)

          );
        }

        /// <summary>
        /// turns a Day class type to a XML type
        /// </summary>
        /// <param name="day"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static XElement toXML(this Day day)
        {
            return new XElement("Day",
                new XElement("start_hour", day.start_hour),
                new XElement("start_minute", day.start_minute),
                new XElement("finish_hour", day.finish_hour),
                new XElement("finish_minute", day.finish_minute),
           new XElement("string_start", day.string_start),
            new XElement("string_finish", day.string_finish));
        }

        public static Day toDay(this XElement dayXml)
        {
            Day day = null;
            if (dayXml == null)
            {
                return day;
            }
            day = new Day
            {
                start_hour = Int32.Parse(dayXml.Element("start_hour").Value),
                start_minute = Int32.Parse(dayXml.Element("start_minute").Value),
                finish_hour = Int32.Parse(dayXml.Element("finish_hour").Value),
                finish_minute = Int32.Parse(dayXml.Element("finish_minute").Value),
                 string_start = dayXml.Element("string_start").Value,
                string_finish = dayXml.Element("string_finish").Value
            };


            return day;
        }

        public static Nanny toNanny(this XElement NannyXml)
        {
            Nanny nanny = null;

            if (NannyXml == null)
            {
                return nanny;
            }
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
                maxAgeOfKid = Int32.Parse(NannyXml.Element("maxAgeOfKid").Value),
                doesWorkPerHour = Boolean.Parse(NannyXml.Element("doesWorkPerHour").Value),
                hourWage = Int32.Parse(NannyXml.Element("hourWage").Value),
                monthlyWage = Int32.Parse(NannyXml.Element("monthlyWage").Value),

                daysOfWork = (from e in NannyXml.Element("daysOfWork").Elements("Days")
                              select Boolean.Parse(e.Value)).ToArray(),
                hoursOfWork = (from d in NannyXml.Element("hoursOfWork").Elements("Day")
                               select d.toDay()).ToArray(),

                hasGovVacationDays = Boolean.Parse(NannyXml.Element("hasGovVacationDays").Value),
                Recommendations = NannyXml.Element("Recommendations").Value,
                numberOfSignedContracts = Int32.Parse(NannyXml.Element("numberOfSignedContracts").Value),


            };
            return nanny;
        }

        public static Mother toMother(this XElement motherXml)
        {
            Mother mother = null;

            if (motherXml == null)
            {
                return mother;
            }

            mother = new Mother
            {
                id = Int32.Parse(motherXml.Element("id").Value),
                familyName = motherXml.Element("familyName").Value,
                firstName = motherXml.Element("firstName").Value,
                phoneNumber = motherXml.Element("phoneNumber").Value,
                address = motherXml.Element("address").Value,
                addressRadius = Int32.Parse(motherXml.Element("addressRadius").Value),
                wantsATrialMeeting = Boolean.Parse(motherXml.Element("wantsATrialMeeting").Value),
                comments = motherXml.Element("comments").Value,

                daysOfNanny = (from e in motherXml.Element("daysOfNanny").Elements("Days")
                               select Boolean.Parse(e.Value)).ToArray(),
                hoursByNanny = (from d in motherXml.Element("hoursByNanny").Elements("Day")
                                select d.toDay()).ToArray(),
            };
            return mother;
        }

        public static Child toChild(this XElement childXml)
        {
            Child child = null;

            if (childXml != null)
            {
                child = new Child
                {
                    id = Int32.Parse(childXml.Element("id").Value),
                    name = childXml.Element("name").Value,
                    momsId = Int32.Parse(childXml.Element("momsId").Value),
                    birthday = DateTime.Parse(childXml.Element("birthday").Value),
                    hasSpecialNeeds = Boolean.Parse(childXml.Element("hasSpecialNeeds").Value),
                    specialNeeds = childXml.Element("specialNeeds").Value,
                };
            }

            return child;
        }

        public static Contract toContract(this XElement contractXml)
        {
            Contract contract = null;

            if (contractXml != null)
            {
                contract = new Contract
                {
                    numberOfContract = Int32.Parse(contractXml.Element("numberOfContract").Value),
                    NannysId = Int32.Parse(contractXml.Element("NannysId").Value),
                    childId = Int32.Parse(contractXml.Element("childId").Value),
                    isSingedContract = Boolean.Parse(contractXml.Element("isSingedContract").Value),
                    moneyPerHour = double.Parse(contractXml.Element("moneyPerHour").Value),
                    monthSalary = double.Parse(contractXml.Element("monthSalary").Value),
                    isMonthContract = Boolean.Parse(contractXml.Element("isMonthContract").Value),
                    StartDate = DateTime.Parse(contractXml.Element("StartDate").Value),
                    ExpirationDate = DateTime.Parse(contractXml.Element("ExpirationDate").Value),
                    Distance= Int32.Parse(contractXml.Element("Distance").Value),

                };
            }

            return contract;
        }

    }
}
