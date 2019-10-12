export class request{
    
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
        
    private lName : string;
    public getlName() : string {
        return this.lName;
    }
    public setlName(v : string) {
        this.lName = v;
    }

    public getfullName() : string {
        return this.fName + this.lName;
    }
    
    private userId : Number;
    public getuserId() : Number {
        return this.userId;
    }
    public setuserId(v : Number) {
        this.userId = v;
    }
    
    private title : string;
    public gettitle() : string {
        return this.title;
    }
    public settitle(v : string) {
        this.title = v;
    }
    
    
    private content : string;
    public getcontent() : string {
        return this.content;
    }
    public setcontent(v : string) {
        this.content = v;
    }
    
    
    private dateRequest : Date;
    public getjoinDate() : Date {
        return this.dateRequest;
    }
    public setjoinDate(v : Date) {
        this.dateRequest = v;
    }
    
}