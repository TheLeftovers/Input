package project.pkg56;

import java.awt.Toolkit;
import java.awt.event.WindowEvent;
import static java.awt.image.ImageObserver.WIDTH;
import java.sql.*;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.swing.JOptionPane;

public class LoginFrame extends javax.swing.JFrame {

    Connection con;
    Statement st;
    ResultSet rs;
    static String user;
    static String pass;
    static String clear;
    
    public LoginFrame() {
        initComponents();
        connect();
    }
    
    public void connect(){
        try{
            String DBpass = JOptionPane.showInputDialog(rootPane, "", "DB Password ?", WIDTH);
            Class.forName("org.postgresql.Driver");
            con = DriverManager.getConnection("jdbc:postgresql://localhost:5432/Project 56", "postgres", ""+DBpass+"");
            if(con != null)
                System.out.println("Connected LoginFrame");
            st = con.createStatement();
        }
        catch(Exception e){
            e.printStackTrace();
        }
    }
    
    public void loginFull(){
        System.out.println("Full login");
        closeFrame();
        LoginFullFrame LF = new LoginFullFrame();
        LF.setVisible(true);  
    }
    
    public void loginLimited(){
        System.out.println("Limited login");
        closeFrame();
        LoginLimitedFrame LL = new LoginLimitedFrame();
        LL.setVisible(true);
    }
    
    public void closeFrame(){
        WindowEvent winClosingEvent = new WindowEvent(this,WindowEvent.WINDOW_CLOS­ING);
        Toolkit.getDefaultToolkit().getSystemEve­ntQueue().postEvent(winClosingEvent);
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        PasField = new javax.swing.JPasswordField();
        UserText = new javax.swing.JLabel();
        PasText = new javax.swing.JLabel();
        LoginB = new javax.swing.JButton();
        SignupB = new javax.swing.JButton();
        UserField = new javax.swing.JTextField();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);

        UserText.setText("Username");

        PasText.setText("Password");

        LoginB.setText("Login");
        LoginB.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                LoginBActionPerformed(evt);
            }
        });

        SignupB.setText("Sign up");
        SignupB.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                SignupBActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(82, 82, 82)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(LoginB, javax.swing.GroupLayout.PREFERRED_SIZE, 90, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 36, Short.MAX_VALUE)
                        .addComponent(SignupB, javax.swing.GroupLayout.PREFERRED_SIZE, 90, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(UserText)
                            .addComponent(PasText))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(PasField)
                            .addComponent(UserField, javax.swing.GroupLayout.DEFAULT_SIZE, 150, Short.MAX_VALUE))))
                .addContainerGap(97, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(44, 44, 44)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(UserText)
                    .addComponent(UserField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(34, 34, 34)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(PasField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(PasText))
                .addGap(32, 32, 32)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(LoginB)
                    .addComponent(SignupB))
                .addContainerGap(61, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void LoginBActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_LoginBActionPerformed
        try{
            this.user = UserField.getText();
            this.pass = PasField.getText();
            String sql = "select username from login where username = '"+user+"'";
            String sql2 = "select username,password from login where username = '"+user+"'and password = '"+pass+"'";
            String sql3 = "select clearance from login where username = '"+user+"'";
            rs = st.executeQuery(sql3);
            while(rs.next()){
                this.clear = rs.getString("clearance");
            }  
            rs = st.executeQuery(sql);            
            int count = 0;
            while(rs.next()){
                count = count + 1;
            }if(count == 1){
                rs = st.executeQuery(sql2);
                int count2 = 0;
                while(rs.next()){
                    count2 = count2 + 1;
                }if(count2 == 1){
                    JOptionPane.showMessageDialog(null, "Login succes!");
                    if(clear.equals("full")){
                        loginFull();
                    }else{
                        loginLimited();
                    }                  
                }else{
                    JOptionPane.showMessageDialog(null, "Password is wrong");
                }                        
            }else{
                JOptionPane.showMessageDialog(null, "Username is wrong");
            }
        } catch(Exception ex){
            ex.printStackTrace();
        }
    }//GEN-LAST:event_LoginBActionPerformed

    private void SignupBActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_SignupBActionPerformed
        try{
            String SUuser = JOptionPane.showInputDialog(rootPane, "", "Username ?", WIDTH);
            String SUpass = JOptionPane.showInputDialog(rootPane, "", "Password ?", WIDTH);
            String SUclear = JOptionPane.showInputDialog(rootPane, "", "Clearance ? full / limited", WIDTH);
            if(SUclear.equals("limited") || SUclear.equals("full")){ 
                String sql = "insert into login (username, password, clearance) values('"+SUuser+"', '"+SUpass+"', '"+SUclear+"')";
                st.execute(sql);
            }else{
                JOptionPane.showMessageDialog(null, "Clearance must be full or limited");
                SignupBActionPerformed(evt);
            }            
        } catch(Exception ex){
            ex.printStackTrace();
        }
    }//GEN-LAST:event_SignupBActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(LoginFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(LoginFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(LoginFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(LoginFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new LoginFrame().setVisible(true);
            }
        });
    }   
    

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton LoginB;
    private javax.swing.JPasswordField PasField;
    private javax.swing.JLabel PasText;
    private javax.swing.JButton SignupB;
    private javax.swing.JTextField UserField;
    private javax.swing.JLabel UserText;
    // End of variables declaration//GEN-END:variables

    public void persist(Object object) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("Project_56PU");
        EntityManager em = emf.createEntityManager();
        em.getTransaction().begin();
        try {
            em.persist(object);
            em.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
            em.getTransaction().rollback();
        } finally {
            em.close();
        }
    }
}
