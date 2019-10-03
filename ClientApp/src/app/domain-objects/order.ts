export class order{
    
    private orderId : Number;
    public getorderId() : Number {
        return this.orderId;
    }
    public setorderId(v : Number) {
        this.orderId = v;
    }
    
    
    private userId : Number;
    public getuserId() : Number {
        return this.userId;
    }
    public setuserId(v : Number) {
        this.userId = v;
    }
    
    
    private movieId : Number;
    public getmovieId() : Number {
        return this.movieId;
    }
    public setmovieId(v : Number) {
        this.movieId = v;
    }
    
    
    private dateOrder : Date;
    public getdateOrder() : Date {
        return this.dateOrder;
    }
    public setdateOrder(v : Date) {
        this.dateOrder = v;
    }
    
}