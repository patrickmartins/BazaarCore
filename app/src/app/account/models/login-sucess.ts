import { JwtToken } from "./login";
import { User } from "./user";

export class LoginSucess {
    public user: User = new User;
	public token: JwtToken = new JwtToken;
}