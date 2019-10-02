export class userInfo{
    
    private email : string;
    public getemail() : string {
        return this.email;
    }
    public setemail(v : string) {
        this.email = v;
    }
    
    
    private fName : string;
    public getfName() : string {
        return this.fName;
    }
    public setfName(v : string) {
        this.fName = v;
    }
    
    
    private lname : string;
    public getlname() : string {
        return this.lname;
    }
    public setlname(v : string) {
        this.lname = v;
    }
    
    
    private joinDate : Date;
    public getjoinDate() : Date {
        return this.joinDate;
    }
    public setjoinDate(v : Date) {
        this.joinDate = v;
    }
    
    private gender : boolean;
    public getgender() : boolean {
        return this.gender;
    }
    public setgender(v : boolean) {
        this.gender = v;
    }
    
    
}