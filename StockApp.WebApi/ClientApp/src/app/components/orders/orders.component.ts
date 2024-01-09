import { OrdersService } from 'src/app/services/orders/orders.service';
import { BehaviorSubject } from 'rxjs';
import { SignalRService } from './../../services/signalR/signal-r.service';
import { Component, OnDestroy, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateUpdateOrderComponent } from './create-update-order/create-update-order.component';
import { Order } from 'src/app/models/order';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css'],
})
export class OrdersComponent implements OnInit, OnDestroy {
  modalRef?: BsModalRef;
  orders: Order[] = [];

  constructor(
    private signalRService: SignalRService,
    private modalService: BsModalService,
    private ordersService: OrdersService
  ) {
    this.signalRService.startConnection();

    this.signalRService.addUpdatedStocksListener((response) => {});

    this.getAddOrUpdatedOrder();
  }

  ngOnInit(): void {
    this.getAllOrders();
  }

  getAllOrders() {
    this.ordersService.getAll().subscribe((response: any) => {
      this.orders = response;
    });
  }
  openModal() {
    this.modalRef = this.modalService.show(CreateUpdateOrderComponent);
  }
  getAddOrUpdatedOrder() {
    this.ordersService.orderThread$.subscribe((response: Order) => {
      this.orders.push(response);
      this.modalRef?.hide();
    });
  }
  ngOnDestroy(): void {
    this.signalRService.stopHubConnection();
  }
}
