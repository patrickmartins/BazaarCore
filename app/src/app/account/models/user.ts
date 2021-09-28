import { environment } from "src/environments/environment";

export class User {
    name: string = "";
    lastName: string = "";
    email: string = "";
    avatar: string = "";

    public get avatarUrl() {
        return this.avatar !== "" ? `${environment.urlBase}image/${this.avatar}` : "";
    }
}