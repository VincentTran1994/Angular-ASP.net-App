export class user{
    
    private userId : Number ;
    public getuserId() : Number  {
        return this.userId;
    }
    public setuserId(v : Number ) {
        this.userId = v;
    }
    
    
    
    private email : string;
    public getemail() : string {
        return this.email;
    }
    public setemail(v : string) {
        this.email = v;
    }
    
    
    private pass : string;
    public getpass() : string {
        return this.pass;
    }
    public setpass(v : string) {
        this.pass = v;
    }
    
    
}