import { IModel } from "src/app/common/models/model";
import { JwtToken } from "./jwt.token";
import { User } from "./user";

export class LoginSucess implements IModel<LoginSucess> {
    public user!: User;
	public token!: JwtToken;

	public createNew(params: any): LoginSucess | undefined {
		if(!params)
			return undefined;

		let model = new LoginSucess();

		if(params) {
			model.user = new User().createNew(params.user)!;
			model.token = new JwtToken().createNew(params.token)!;
		}

		return model;
	}
}