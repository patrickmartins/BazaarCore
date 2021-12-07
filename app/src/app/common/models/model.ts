export interface IModel<TType> {	
	createNew(params: any): TType | undefined;
}

declare global {
    interface Array<T> {
        createNew<TType extends IModel<TType>>(itens: any): Array<T>;
    }
}
