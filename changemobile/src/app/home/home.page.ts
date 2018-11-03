import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  private productPrice;
  private inputMoney;
  private respChangeAmount: number;
  private thousand: number = 0;
  private fiveHundred: number = 0;
  private oneHundred: number = 0;
  private fifty: number = 0;
  private twenty: number = 0;
  private five: number = 0;
  private one: number = 0;
  private mss: string = "";

  constructor(private http: HttpClient) {
  }

  private Submit() {

    if (this.productPrice <= 0 || this.inputMoney <= 0 || (this.productPrice > this.inputMoney)) {
      this.mss = "ใส่ข้อมูลไม่เหมาะสม";
      return;
    }

    var url = 'http://localhost:5000/api/values/' + this.productPrice + '/' + this.inputMoney;
    this.http.get<any>(url)
      .subscribe(it => {
        this.respChangeAmount = it.changeAmount;
        this.thousand = it.changeBanks[0];
        this.fiveHundred = it.changeBanks[1];
        this.oneHundred = it.changeBanks[2];
        this.fifty = it.changeBanks[3];
        this.twenty = it.changeBanks[4];
        this.five = it.changeBanks[5];
        this.one = it.changeBanks[6];
      });
  }

}