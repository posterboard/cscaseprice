/*
Brian Huang
3/~/22
FBI
Extra: Always print gender
*/
import java.util.Arrays;

class Main {
  public static void main(String[] args) {
    
    
    //from the arrays provided
    String[] name = {"Bowman", "Walker", "Christian", "Edwards", "Cummings", "Halpern", "Scott", "Rhineheart", "Haley", "Brooks"};
    String[] address = {"Canaan", "Nenwark", "Hardwick", "Montgomery", "Trenton", "Liverpool", "Sheridan", "Houson", "Westfield", "Syosset"};
    String[] state = {"CT", "NJ", "VT", "AL", "NJ", "NY", "WY", "TX", "NJ", "NY"};
    String[] car =  {"Saturn", "Oldsmobile", "Chevrolet", "Chevrolet", "Ford", "Chevrolet", "Ford", "Cadillac", "Honda", "Ford"};
    char[] sex = {'M', 'F', 'M', 'M', 'M', 'F', 'M', 'F', 'F', 'M'};
    int[] age = {48, 39, 46, 71, 31, 38, 51, 62, 22, 32};
    int[] salary = {18000, 27000, 59000, 78000, 25000, 45000, 19000, 91000, 33000, 40000};
    int[] savings = {4200, 3600, 1900, 500, 7800, 12000, 400, 53200, 4700, 3900};
    int[] year = {2009, 2006, 2010, 2013, 2009, 2012, 2008, 2017, 2004, 2011};

    int count=0;
    //Case 1
    System.out.println("Case 1 for Inspector Holmes");
    for (int i = 0; i < 10; i++) {
      if (sex[i] == 'M' && age[i] > 30 && car[i].equals("Ford") && salary[i] > 20000) {
        System.out.println("Name: " + name[i] + "\nAdress: " + address[i]);
        
        count++;
      }
    }
    
    count = 0;

    //Case 2
    System.out.println("Case 2 for Inspector Clouseau");
    for (int i = 0; i < 10; i++) {
      if ((car[i].equals("Chevrolet") || car[i].equals("Ford") || car[i].equals("Honda")) && salary[i] > 15000 && savings[i] < 20000) {
        System.out.println("Name: " + name[i]);
        System.out.println("Gender: "+sex[i]);
        count++;
      }
    }
  
    count = 0;

    //Case 3
    System.out.println("Case 3 for Inspector Simon");
    for (int i = 0; i < 10; i++) {
      if (sex[i] == 'F') {
        System.out.println("Name: " + name[i] + "\nModel: " + car[i] + "\nYear: " + year[i]);
        System.out.println("Gender: "+sex[i]);
        count++;
      }
    }
    
    count = 0;

    //Case 4
    System.out.println("Case 4 for Pink Panther (undercover)");
    for (int i = 0; i < 10; i++) {
      if (sex[i] == 'M' && age[i] < 35 && car[i].equals("Ford") && state[i].equals("NJ")) {
        System.out.println("Name: " + name[i]);
        System.out.println("Gender: "+sex[i]);
        count++;
      }
    }
   
    count = 0;
  }
}
