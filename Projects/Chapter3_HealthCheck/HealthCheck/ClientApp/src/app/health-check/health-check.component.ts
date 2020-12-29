//At the start of the file, we made sure to import all the Angular directives,
//pipes, services, and Components—in one word, modules—that we need
//throughout the whole class.

import {Component, Inject } from '@angular/core';
import {HttpClient } from '@angular/common/http';






/*In the Component's constructor, we instantiated a HttpClient service and
a baseUrl variable using Dependency Injection (DI); the baseUrl value
is being set by making use of the BASE_URL provider, defined in the
/ClientApp/src/main.ts file, which we briefly introduced in Chapter
2, Looking Around. As we can see by looking at that file's source code, it will
resolve to our application's root URL: such a value is required by the
HttpClient service, to build the URL that will be used to fetch the data
from the server with an HTTP GET request to the .NET HealthChecks
middleware that we set up earlier on (see the 'hc' string).
*/

@Component({
    selector: 'app-health-check',
    templateUrl: './health-check.component.html',
    styleUrls: ['./health-check.component.css']
  })



export class HealthCheckComponent {
  public result: Result;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string){
    }

    ngOnInit() {
      this.http.get<Result>(this.baseUrl + "hc").subscribe(result => {
        this.result = result;
      },
      error => console.error(error));
    }
}

/*
Last but not least, we defined two interfaces to deal with the JSON request
we're expecting to receive from the HealthChecks middleware: Result
and Check, which we designed to host the whole JSON resulting object and
each element of the internal array, respectively.
*/

interface Result {
  checks: Check[];
  totalStatus: string;
  totalResponseTime: number;
}

interface Check {
  name: string;
  status: string;
  description: string;
  responseTime: number;
}



