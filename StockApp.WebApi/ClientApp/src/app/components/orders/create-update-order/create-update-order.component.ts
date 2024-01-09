import { CommuncationService } from './../../../services/internal/communcation.service';
import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth/auth.service';
import { OrdersService } from 'src/app/services/orders/orders.service';
import { StocksService } from 'src/app/services/stocks/stocks.service';

@Component({
  selector: 'create-update-order',
  templateUrl: './create-update-order.component.html',
  styleUrls: ['./create-update-order.component.css'],
})
export class CreateUpdateOrderComponent implements OnInit {
  orderForm!: FormGroup;
  stocks: any = [];
  constructor(
    private fb: FormBuilder,
    public modalRef: BsModalRef,
    private ordersService: OrdersService,
    private stocksService: StocksService,
    private authService: AuthService,
    private toastrService: ToastrService
  ) {}
  ngOnInit(): void {
    this.createForm();
    this.getAllStocks();
  }

  getAllStocks() {
    this.stocksService.getAll().subscribe((response) => {
      this.stocks = response;
      console.log(this.stocks);
    });
  }

  createForm() {
    this.orderForm = this.fb.group({
      stockId: [],
      quantity: [],
    });
  }

  onSave() {
    let data = {
      userId: this.authService.getUserId(),
      ...this.orderForm.value,
    };

    this.ordersService.create(data).subscribe((response: any) => {
      this.toastrService.show('Order Added Succesfully');
      this.ordersService.orderSource.next(response);
    });
  }
}
