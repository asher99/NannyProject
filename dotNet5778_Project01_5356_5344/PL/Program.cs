using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            #region introduction

            Console.WriteLine("Welcome to our program!\nwe will present the initial stage of our project via this console app.");
            Console.WriteLine("To start the program, please press \"Enter\":\n");
            Console.ReadKey();
            #endregion

            #region peoples

            Console.WriteLine("Here we will introduce the people that participate in this program:");
            System.Threading.Thread.Sleep(4000);

            Nanny Sarit = new Nanny("Friedman", "Sarit", "Tal Institute - College of Technology", 758556411, new DateTime(1995, 7, 15), 508494561, true, 40, 1700, 12, 4, 24);
            Console.WriteLine(Sarit);
            System.Threading.Thread.Sleep(2500);

            Nanny Chagit = new Nanny("Cohen", "Chagit", "jaffa street 31 Jerusalem", 647859321, new DateTime(1992, 11, 2), 504741121, true, 75, 1400, 6, 10, 36);
            Console.WriteLine(Chagit);
            System.Threading.Thread.Sleep(2500);

            Nanny Avigail = new Nanny("Morad", "Avigail", "Haneviaim street 25 Jerusalem", 812535224, new DateTime(1996, 3, 28), 509822451, false, 0, 1660, 9, 4, 32);
            Console.WriteLine(Avigail);
            System.Threading.Thread.Sleep(2500);

            Nanny Chaya = new Nanny("Scholssberg", "Chaya", "Nikanor street 15, Jerualem", 316525442, new DateTime(2002, 10, 25), 528494531, true, 45, 1300, 12, 7, 32);
            Console.WriteLine(Chaya);
            System.Threading.Thread.Sleep(2500);

            Console.WriteLine("**********");

            Mother Rivka = new Mother("Aflalo", "Rivka", "Lev Academic Center", 456223300, 502283470);
            Console.WriteLine(Rivka);
            System.Threading.Thread.Sleep(2500);

            Mother Hadasa = new Mother("Hadasa", "Weiss", "King George 20 Jerusalem", 316522107, 523566464);
            Console.WriteLine(Hadasa);
            System.Threading.Thread.Sleep(2500);

            Mother Yael = new Mother("Adler", "Yael", "Yermiyahu street 14 Jerusalem", 316522488, 523578461);
            Console.WriteLine(Yael);
            System.Threading.Thread.Sleep(2500);

            Console.WriteLine("**********");


            Child Dudi = new Child("Dudi", 212235799, 456223300, new DateTime(2016, 5, 18));
            Console.WriteLine(Dudi);
            System.Threading.Thread.Sleep(2500);

            Child Yossi = new Child("Yossi", 212277899, 316522107, new DateTime(2015, 11, 11));
            Console.WriteLine(Yossi);
            System.Threading.Thread.Sleep(2500);

            Child Alon = new Child("Alon", 214566512, 316522107, new DateTime(2017, 1, 18));
            Console.WriteLine(Alon);
            System.Threading.Thread.Sleep(2500);

            Child Dani = new Child("Dani", 714565899, 316522488, new DateTime(2017, 8, 11));
            Console.WriteLine(Dani);
            System.Threading.Thread.Sleep(2500);

            Child Miryam = new Child("Miryam", 263255119, 456223300, new DateTime(2016, 12, 24));
            Console.WriteLine(Miryam);
            System.Threading.Thread.Sleep(2500);


            Console.WriteLine("**********\nnow lets make some contracts! to do so please press \"Enter\":\n");
            Console.ReadKey();
            #endregion 

            #region contracts
            Contract Sarit_and_Dudi = new Contract(Sarit, Dudi, false);
            Console.WriteLine(Sarit_and_Dudi);
            System.Threading.Thread.Sleep(2500);

            Contract Avigail_and_Dani = new Contract(Avigail, Dani, false);
            Console.WriteLine(Avigail_and_Dani);
            System.Threading.Thread.Sleep(2500);

            Contract Chaya_and_Miryam = new Contract(Chaya, Miryam, true);
            Console.WriteLine(Chaya_and_Miryam);
            System.Threading.Thread.Sleep(2500);

            Contract Chagit_and_Yossi = new Contract(Chagit, Yossi, true);
            Console.WriteLine(Chagit_and_Yossi);
            System.Threading.Thread.Sleep(2500);

            Contract Chagit_and_Alon = new Contract(Chagit, Alon, true);
            Console.WriteLine(Chagit_and_Alon);
            System.Threading.Thread.Sleep(2500);

            Console.WriteLine("**********\nas you can see, all the contracts number are -1. this mean that the contract is not signed.");
            Console.WriteLine("also note that the two last contracts are two brothers with the same nanny, but the salary is the same, for now.");
            Console.WriteLine("the second contract salary is 0, interesting...");
            Console.WriteLine("in order to sign the contracts, we need to send the contracts all the way to data source. please press \"Enter\" to continue:\n");
            
            Console.ReadKey();


            #endregion

            #region bl_calls


            Console.WriteLine("sending to data source all the objects... \nstay in focus, there are few errors in the data and exceptions will appear!\n\n");
            System.Threading.Thread.Sleep(5000);

            IBL_imp program_bl = new IBL_imp();


            program_bl.addNanny(Sarit);
            program_bl.addNanny(Chagit);
            program_bl.addNanny(Avigail);
            try
            {
                program_bl.addNanny(Chaya);
            }
            catch (Exception first_teenNanny)
            {
                Console.WriteLine(first_teenNanny.Message);
                Console.WriteLine("as you can see, the BL detect that Chaya is too young. lets continue, press \"Enter\"\n\n:");
                Console.ReadKey();
            }

            program_bl.addMother(Rivka);
            program_bl.addMother(Hadasa);
            program_bl.addMother(Yael);

            program_bl.addChild(Dudi);
            program_bl.addChild(Yossi);
            program_bl.addChild(Alon);
            program_bl.addChild(Dani);


            program_bl.addContract(Sarit_and_Dudi);
            try
            {
                program_bl.addContract(Avigail_and_Dani);
            }
            catch (Exception second_wrongTypeContract)
            {
                Console.WriteLine(second_wrongTypeContract.Message);
                Console.WriteLine("as you can see, the BL detect that Avigail works only per month but the contract was per hour! lets continue, press \"Enter\"\n\n:");
                Console.ReadKey();
            }

            program_bl.addContract(Chagit_and_Yossi);
            program_bl.addContract(Chagit_and_Alon);

            try
            {
                program_bl.addContract(Chaya_and_Miryam);
            }
            catch (Exception third_missingNanny)
            {
                Console.WriteLine(third_missingNanny.Message);
                Console.WriteLine("as you can see, the BL detect that Chaya not in DS. remember that she was too young? lets continue, press \"Enter\"\n\n:");
                Console.ReadKey();
            }
            #endregion

            #region print signed contract

            Console.WriteLine("*************\nwell, lets see the contracts that survive the BL. we are abut to call and print them:\n\n");
            Console.WriteLine("List of all signed contract:\n");
            System.Threading.Thread.Sleep(2500);

            List<Contract> currentListOfContracts = program_bl.getListOfContract().ToList<Contract>();
            foreach (Contract temp in currentListOfContracts)
            {
                Console.WriteLine(temp);
                System.Threading.Thread.Sleep(2500);
            }

            Console.WriteLine("\nnotice that now the brothers contracts are different, the second got a discount!\n");
            Console.WriteLine("to continue press Enter!");
            Console.ReadKey();
            #endregion

            #region googleApi
            Console.WriteLine("************\nlets examine the googleApi tool, and ask for the distance between Sarit and Dani:\n");
            int distance = program_bl.distanceBetweenAddresses(Sarit.address, Rivka.address);

            Console.WriteLine("Sarit lives in: " + Sarit.address + "and dudi in his mother house: " + Rivka.address +
                "\n the distance is: " + distance + " meters!");

            #endregion

            Console.WriteLine("to continue press Enter!");
            Console.ReadKey();

            Console.WriteLine("\nprogram finished!");

        }
    }
}
