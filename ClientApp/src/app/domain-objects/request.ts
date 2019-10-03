export class request{
    
    private email : string;
    public getemail() : string {
        return this.email;
    }
    public setemail(v : string) {
        this.email = v;
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