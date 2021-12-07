import { IModel } from "src/app/common/models/model";

export class JwtToken implements IModel<JwtToken> {
    public accessToken: string = '';
    public expireIn: Date = new Date();

	public createNew(params: any): JwtToken | undefined {
		if(!params)
			return undefined;

		let model = new JwtToken();

		if(params) {
			model.accessToken = params.accessToken;
			model.expireIn = params.expireIn;
		}

		return model;
	}
}