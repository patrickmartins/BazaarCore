export class Factory<TType> {

    constructor(private type: (new () => TType)) { }

    public create(): TType {
        return new this.type();
    }
    
}