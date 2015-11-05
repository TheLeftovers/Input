/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package web;

import java.util.ArrayList;
import java.util.List;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import org.hibernate.Criteria;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;
import org.hibernate.criterion.Restrictions;

/**
 *
 * @author Johan Bos
 */
@WebService(serviceName = "getPosition")
public class getPosition {

    /**
     * Web service operation
     */
    @WebMethod(operationName = "getUnitID")
    public ArrayList<Long> getUnitID() {
       SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();
		
		Session session = sessionFactory.getCurrentSession();
                ArrayList<Long> units = new ArrayList<Long>();
		
	
                    session.beginTransaction();
                    List unit = session.createSQLQuery("SELECT DISTINCT p.unit_id FROM positions p").list();
                    
                    
                    
                    if(unit != null){units.addAll(unit);}
                    else{return null;}
                    
			session.getTransaction().commit();		
		
        return units;
    }
    
    /**
     * Web service operation
     */
    @WebMethod(operationName = "getSpeed")
    public ArrayList<Integer> getSpeed() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();
		
		Session session = sessionFactory.getCurrentSession();
                ArrayList<Integer> speeds = new ArrayList<Integer>();
		
	
                    session.beginTransaction();
                    List speed = session.createSQLQuery("SELECT DISTINCT p.speed FROM positions p ORDER BY p.speed DESC").list();
                    
                    
                    
                    if(speed != null){speeds.addAll(speed);}
                    else{return null;}
                    
			session.getTransaction().commit();		
		
        return speeds;
    }
}
