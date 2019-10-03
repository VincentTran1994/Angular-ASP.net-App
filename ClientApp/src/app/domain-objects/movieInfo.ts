export class movieInfo{
    
    private movieId : Number;
    public getmovieId() : Number {
        return this.movieId;
    }
    public setmovieId(v : Number) {
        this.movieId = v;
    }    
    
    private movieName : string;
    public getmovieName() : string {
        return this.movieName;
    }
    public setmovieName(v : string) {
        this.movieName = v;
    }
    
    private author : string;
    public getauthor() : string {
        return this.author;
    }
    public setauthor(v : string) {
        this.author = v;
    }
    
    private pulish : Date;
    public getpulish() : Date {
        return this.pulish;
    }
    public setpulish(v : Date) {
        this.pulish = v;
    }
    
}