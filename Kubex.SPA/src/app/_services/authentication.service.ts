import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private baseUrl = environment.apiUrl;
  private currentUserSubject: BehaviorSubject<any>;
  public currentUser: Observable<User>;

  constructor(private http: HttpClient) {
      this.currentUserSubject = new BehaviorSubject<any>(JSON.parse(localStorage.getItem('currentUser')));
      this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue() {
      return this.currentUserSubject.value;
  }

  login(username, password) {
      return this.http.post<any>(`${this.baseUrl}/auth/login`, { username, password })
          .pipe(map(user => {
              // store user details and jwt token in local storage to keep user logged in between page refreshes
              localStorage.setItem('currentUser', JSON.stringify(user));
              this.currentUserSubject.next(user);
              return user;
          }));
  }

  logout() {
      // remove user from local storage and set current user to null
      localStorage.removeItem('currentUser');
      this.currentUserSubject.next(null);
  }
}
