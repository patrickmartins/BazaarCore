import { Injectable } from "@angular/core";
import { IModel } from "../common/models/model";

@Injectable({
    providedIn: 'root'
})

export class LocalStorageHelper {

    public saveData(key: string, data: any) {
        localStorage.setItem(key, JSON.stringify(data));
    }

    public getData<TType>(key: string, returnType?: (new () => IModel<TType>)): TType | undefined {
        let data = localStorage.getItem(key);
		
		if(data === null)
			return;

		let obj = JSON.parse(data);
		
		if (returnType) {
			let entity = new returnType();

			return Object.assign(entity.createNew(obj), obj);
		}

        return obj;
    }

    public removeData(key: string) {
        localStorage.removeItem(key);
    }

    public dataExists(key: string): boolean {
        return localStorage.hasOwnProperty(key);
    }
}