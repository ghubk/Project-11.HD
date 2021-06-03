#include "application.h"
#include "LiquidCrystal/LiquidCrystal.h"


int buzzer = A3;
int state = 0;

LiquidCrystal lcd(5, 4, 3, 2, 1, 0);

void setup() {
    
    
    // set up the LCD's number of columns and rows: 
    lcd.begin(16,2);
    // Print a message to the LCD.
    lcd.print("MedProtecc");
    
    
    pinMode(buzzer, OUTPUT);
    analogWrite(buzzer, LOW);
    
    
    Particle.function("buzzeralarmon", buzzer_alarm_manual);
    
    
    //Particle.subscribe("Intruder", intruderalertscreen, <deviceID>);
    Particle.subscribe("Intruder", buzzeralarm,<deviceID>);
    
    Particle.subscribe("Nointruder", nointruder, <deviceID>);
    //Particle.variable("Drugs", message, STRING);

}

void loop() {
    
    
    if (Time.now(), "%H:%M:%S" == "00:00:00") 
    {
        lcd.clear();
    }  
  
    //columns and rows
    lcd.setCursor(0,1);
    lcd.print(Time.format(Time.now(), "%H:%M:%S"));
    
}

void nointruder(const char*event, const char*data)
{
    
    lcd.begin(16,2);
    lcd.print("MedProtecc");
    
}

void buzzeralarm(const char *event, const char*data)
{
    
    
    
    for (int i = 0; i<10; i++)
    {
        lcd.clear();
        lcd.print("Intruder");
        lcd.setCursor(0, 1);
        lcd.print("At Medbox");
        
        analogWrite(buzzer, 200);
        delay(1000);
        analogWrite(buzzer, 0);
        delay(500);
    }
    
}



int buzzer_alarm_manual(String buzz)
{
    if(buzz == "on")
    {
        
        analogWrite(buzzer, 200);
        
        return 1;
    }else if(buzz == "off")
    {
        analogWrite(buzzer, 0);
        return 0;
    }else
    {
        return -1;
    }
    
}




//void buzzertrig (const char *event, const char *data )
//{
//    buzzeralarm();
//}

//void intruderalertscreen(const char*event, const char*data)
//{
//    lcd.clear();
//    lcd.print("Intruder");
//    lcd.setCursor(0, 1);
//    lcd.print("At Medbox");
//    delay(10000);
    

//}

//char message(String Message)
//{
//    if(Message == "name")
//    {   lcd.clear();
//        lcd.begin(16,2);
//        lcd.print(;
//        return 1;
//    }else
//    {
//        return 0;
//    }
    
    
//}
