using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace OrderBot
{
    public class Session
    {
        private enum State
        {
            WELCOMING, NAME, GENDER,AGE, EMAIL_ID, CONTACT_NO,MEMBERSHIP_PLAN, MEMBERSHIP_DETAILS,PLANS
        }

        private State nCur = State.WELCOMING;
        private Order oOrder;

        public Session(string sPhone)
        {
            this.oOrder = new Order();
           // this.oOrder.Phone = sPhone;
        }

        public List<String> OnMessage(String sInMessage)
        {
            List<String> aMessages = new List<string>();

            /* if (!IsValidEmail(sInMessage.Trim()) && this.nCur == State.EMAIL_ID)
             {
                 this.nCur = State.EMAIL_ID;
                 aMessages.Add("Please Enter a Valid Email.");
             }*/
            switch (this.nCur)
            {
                case State.WELCOMING:
                    this.oOrder.Welcome = sInMessage;
                    aMessages.Add("Hello! Welcome to FitForLess");

                    aMessages.Add("Can I have some information about you");

                    this.nCur = State.NAME;
                    break;
                case State.NAME:

                    aMessages.Add("Please provide your fullname");

                    this.nCur = State.GENDER;
                    
                    break;

                case State.GENDER:
                    this.oOrder.Name = sInMessage;
                    aMessages.Add("Your full name is " + this.oOrder.Name);
                    aMessages.Add("Please provide your Gender");
                    this.nCur = State.AGE;
                  
                    break;
                case State.AGE:
                    this.oOrder.Gender = sInMessage;
                    aMessages.Add("Your Gender is " + this.oOrder.Gender);
                    aMessages.Add("Please provide your Age");
                    this.nCur = State.EMAIL_ID;
                    
                    break;
                case State.EMAIL_ID:
                    this.oOrder.Age = sInMessage;
                    aMessages.Add("Your Age is " + this.oOrder.Age);
                    aMessages.Add("Please provide your Email id");
                    this.nCur = State.CONTACT_NO;                
                    break;
                case State.CONTACT_NO:
                    this.oOrder.Emailid = sInMessage;
                    aMessages.Add("Your email id is " + this.oOrder.Emailid);
                    aMessages.Add("Please provide your Contact no");
                    this.nCur = State.MEMBERSHIP_PLAN;
                  
                    break;

                case State.MEMBERSHIP_PLAN:

                    this.oOrder.ContactNo = sInMessage;
                    aMessages.Add("Your Contact No is " + this.oOrder.ContactNo);
                    
                    aMessages.Add("Thank you for providing your personal information");

                    aMessages.Add("We offer various membership types to suit your needs. "
                                            + "Three membership tyoes are available -[Gold], [Plantinum], and [Silver].");
                    aMessages.Add("Would you like me to explain the differences between these plans ? ");
                    this.nCur = State.MEMBERSHIP_DETAILS;

                    break;
                                  

                case State.MEMBERSHIP_DETAILS:
                  
                    aMessages.Add("\"The Silver plan costs $30/month, the Gold plan costs $60/month, \"\r\n  \"and the Platinum plan is $80/month.");
                    aMessages.Add("What membership plan would you like to enroll (Silver/Gold/Platinum) ");

                    this.nCur = State.PLANS;
                    break;
                case State.PLANS:
                    
                    this.oOrder.Plans = sInMessage;
                    aMessages.Add("Thanks for enrolling to "  + this.oOrder.Plans + " membership");

                    this.oOrder.Save();

                    aMessages.Add("we look forward to seeing you soon");
                    aMessages.Add("Have a great day!");
                   
                    break;

                
            }
            aMessages.ForEach(delegate (String sMessage)
            {
                System.Diagnostics.Debug.WriteLine(sMessage);
            });
            return aMessages;
        }

      

    }
}
