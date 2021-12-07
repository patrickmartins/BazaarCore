import { IModel } from "src/app/common/models/model";
import { environment } from "src/environments/environment";

export class User implements IModel<User> {
	public id!: string;
    public name!: string;
    public lastName!: string;
    public email!: string;
    public avatar!: string;

    public get avatarUrl() {
        return this.avatar !== "" ? `${environment.urlBase}image/${this.avatar}` : "";
    }

	public createNew(params: any): User | undefined {
		if(!params)
			return undefined;

		let user = new User();

		if(params) {
			user.id = params.id;
			user.name = params.name;
			user.lastName = params.lastName;
			user.email = params.email;
			user.avatar = params.avatar;		
		}

		return user;
	}
}