import { IModel } from "src/app/common/models/model";

export class  Category implements IModel<Category> {
	public id!: string;
	public name!: string;

	public createNew(params: any): Category | undefined {
		if(!params)
			return undefined;

		let category = new Category();

		if(params) {
			category.id = params.id;
			category.name = params.name;			
		}

		return category;
	}
}