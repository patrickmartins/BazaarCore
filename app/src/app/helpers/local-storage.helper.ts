import { Injectable } from "@angular/core";
import { Factory } from "../common/factories/factory";

@Injectable({
    providedIn: 'root'
})

export class LocalStorageHelper {

    public saveData(key: string, data: any) {
        localStorage.setItem(key, JSON.stringify(data));
    }

    public getData<TType>(key: string, factory?: Factory<TType>): TType | undefined {
        let data = localStorage.getItem(key);
		
		if(data === null)
			return;

		let obj = JSON.parse(data);
		
		if (factory)
			return Object.assign(factory.create(), obj);

        return obj;
    }

    public removeData(key: string) {
        localStorage.removeItem(key);
    }

    public dataExists(key: string): boolean {
        return localStorage.hasOwnProperty(key);
    }
}