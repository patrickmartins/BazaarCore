import { IModel } from "src/app/common/models/model";
import { environment } from "src/environments/environment";

export class AdBasicModel implements IModel<AdBasicModel> {

	public id!: string;
	public title!: string;
	public idCategory!: string;
	public price!: number;
	public picture!: string;

	public get pictureUrl() {
        return this.picture !== "" ? `${environment.urlBase}image/${this.picture}` : "";
    }

	public createNew(params: any): AdBasicModel | undefined {
		if(!params)
			return undefined;

		let ad = new AdBasicModel();

		if(params) {
			ad.id = params.id;
			ad.title = params.title;
			ad.idCategory = params.idCategory;
			ad.price = params.price;
			ad.picture = params.picture;		
		}

		return ad;
	}
}