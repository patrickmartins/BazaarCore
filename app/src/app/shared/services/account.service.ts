import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { BaseService } from '../../common/services/base.service';
import { LocalStorageHelper } from 'src/app/helpers/local-storage.helper';
import { User } from '../../account/models/user';
import { RegisterModel } from '../../account/models/register';
import { ChangePassword } from '../../account/models/change-password';
import { LoginSucess } from '../../account/models/login-sucess';
import { LoginModel } from '../../account/models/login';
import { JwtToken } from '../../account/models/jwt.token';

@Injectable({
    providedIn: 'root'
})

export class AccountService extends BaseService {

	private _userAuthenticatedSubscription : Subject<User | undefined>;
	private _userAuthenticated : Observable<User | undefined>;

    constructor(httpClient: HttpClient, private localStorage: LocalStorageHelper) {
        super(httpClient);

		this._userAuthenticatedSubscription = new BehaviorSubject(this.localStorage.getData<User>(environment.keyUser, User));
		this._userAuthenticated = this._userAuthenticatedSubscription.asObservable();
    }
	   
    public isAuthenticated(): boolean {
        return this.localStorage.dataExists(environment.keyToken) &&
               this.localStorage.getData(environment.keyToken) != null;        
    }

    public login(login: LoginModel): Observable<LoginSucess> {
        return this.post<LoginSucess>(`${environment.urlBase}account/login`, login, undefined, LoginSucess).pipe(map(this.onSucessLogin, this));
    }

    public register(register: RegisterModel): Observable<any> {
        return this.post(`${environment.urlBase}account/register`, register);
    }

    public changePassword(changePassword: ChangePassword): Observable<any> {
        return this.post(`${environment.urlBase}account/change-password`, changePassword);
    }

	public changeAvatar(imageGuid: string): Observable<any> {
		return this.post(`${environment.urlBase}account/change-avatar`, `"${imageGuid}"`, { headers: { 'Content-Type': 'application/json' }}).pipe(map(() => this.onChangeAvatar(imageGuid)));
    }

    public logout() {
        if (this.localStorage.dataExists(environment.keyToken)) { 
            this.localStorage.removeData(environment.keyToken);
		}

		if (this.localStorage.dataExists(environment.keyUser)) { 
            this.localStorage.removeData(environment.keyUser);
		}
    }

    public getLoggedUser(): Observable<User | undefined> {
        return this._userAuthenticated;
    }

    public getAccessToken(): JwtToken | undefined {
        return this.localStorage.getData(environment.keyToken);
    }

	private onChangeAvatar(imageGuid: string): any {
		let user = this.localStorage.getData<User>(environment.keyUser, User)

		if(user)
			user.avatar = imageGuid;
		
		this.localStorage.saveData(environment.keyUser, user);
		
		this._userAuthenticatedSubscription.next(user);	
    }

    private onSucessLogin(sucess: LoginSucess): LoginSucess {
        this.localStorage.saveData(environment.keyToken, sucess.token);
		this.localStorage.saveData(environment.keyUser, sucess.user);

		this._userAuthenticatedSubscription.next(sucess.user);
		
        return sucess;
    }
}