import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WhatsupComponent } from './whatsup.component';

describe('WhatsupComponent', () => {
  let component: WhatsupComponent;
  let fixture: ComponentFixture<WhatsupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WhatsupComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WhatsupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
