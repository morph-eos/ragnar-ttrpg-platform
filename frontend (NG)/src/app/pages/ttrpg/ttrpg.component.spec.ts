import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TtrpgComponent } from './ttrpg.component';

describe('TtrpgComponent', () => {
  let component: TtrpgComponent;
  let fixture: ComponentFixture<TtrpgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TtrpgComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TtrpgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
