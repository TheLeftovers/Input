/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.person;

/**
 *
 * @author Johan Bos
 */
public class Person {

    private int id;
    private String firstName;
    private String lastName;
    private int Hours;

    public Person(int id, String firstName, String lastName, int Hour) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.Hours = Hours;
    }

    Person() {
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public int getHours() {
        return Hours;
    }

    public void setHours(int Hours) {
        this.Hours = Hours;
    }
  

    @Override
    public String toString() {
        return "Person" + "\n" + "ID: " + id + "\n" + "First Name: " + firstName + "\n" + "Last Name: " + lastName + "\n" + "Hours Worked: " + Hours + "\n";
    }
    
    
   
}
