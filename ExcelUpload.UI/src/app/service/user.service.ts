import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http'
import { User } from '../model/user';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  url = 'http://localhost:7141/api/ExcelDataUpload';

  UploadExcel(formData: FormData): Observable<any> {
    let headers = new HttpHeaders();

    headers = headers.append('Content-Type', 'multipart/form-data');
    headers = headers.append('Accept', 'application/json');

    const httpOptions = { headers: headers };
    
    return this.http.post<any>(this.url + '/UploadExcel', formData, httpOptions);
  }

  //   UploadExcel(formData: FormData): Observable<any> {
  //     const httpOptions = {
  //         headers: new HttpHeaders({
  //             'Accept': 'application/json'
  //         }),
  //         withCredentials: true
  //     };

  //     return this.http.post<any>(this.url + '/ExcelDataUpload/UploadExcel', formData, httpOptions)
  //         .pipe(
  //             catchError(error => this.handleError(error))
  //         );
  // }

  // private handleError(error: any): Observable<never> {
  //     console.error('An error occurred:', error);
  //     return throwError('Something went wrong. Please try again later.');
  // }

  BindUser(): Observable<User[]> {
    return this.http.get<User[]>(this.url + '/UserDetails');
  }
}
