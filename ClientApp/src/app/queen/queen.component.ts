import { Component, Inject } from '@angular/core';
import { Queen } from '../interfaces';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-queen',
    templateUrl: './queen.component.html',
})
export class QueenComponent {
  queen: Queen;

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.route.paramMap.subscribe(params => {
      this.http.get<Queen>(baseUrl + 'api/Queens/' + +params.get('queenId')).subscribe(result => {
        this.queen = result;
        console.log(this.queen);
      }, error => console.error(error));
    });
  }
}
